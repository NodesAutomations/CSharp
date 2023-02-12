### Code to create table of Attribute for selected block
- ref : https://www.keanw.com/2007/06/creating_an_aut_2.html
```csharp

        private const double colWidth = 15.0;
        private const double rowHeight = 3.0;
        private const double textHeight = 1.0;
        private const CellAlignment cellAlign = CellAlignment.MiddleCenter;

        // Helper function to set text height
        // and alignment of specific cells,
        // as well as inserting the text

        static public void SetCellText(Table tb, int row, int col, string value)
        {
            tb.SetAlignment(row, col, cellAlign);
            tb.SetTextHeight(row, col, textHeight);
            tb.SetTextString(row, col, value);
        }

        [CommandMethod("BAT")]
        static public void BlockAttributeTable()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor ed = doc.Editor;

            // Ask for the name of the block to find
            PromptStringOptions opt = new PromptStringOptions("\nEnter name of block to list: ");
            PromptResult pr = ed.GetString(opt);

            if (pr.Status == PromptStatus.OK)
            {
                string blockToFind = pr.StringResult.ToUpper();
                bool embed = false;

                // Ask whether to embed or link the data
                PromptKeywordOptions pko = new PromptKeywordOptions("\nEmbed or link the attribute values: ");
                pko.AllowNone = true;
                pko.Keywords.Add("Embed");
                pko.Keywords.Add("Link");
                pko.Keywords.Default = "Embed";

                PromptResult pkr = ed.GetKeywords(pko);
                if (pkr.Status == PromptStatus.None || pkr.Status == PromptStatus.OK)
                {
                    if (pkr.Status == PromptStatus.None || pkr.StringResult == "Embed")
                    {
                        embed = true;
                    }
                    else
                    {
                        embed = false;
                    }
                }

                Transaction tr = doc.TransactionManager.StartTransaction();

                using (tr)
                {
                    // Let's check the block exists
                    BlockTable bt = (BlockTable)tr.GetObject(doc.Database.BlockTableId, OpenMode.ForRead);

                    if (!bt.Has(blockToFind))
                    {
                        ed.WriteMessage("\nBlock " + blockToFind + " does not exist.");
                    }
                    else
                    {
                        // And go through looking for
                        // attribute definitions
                        StringCollection colNames = new StringCollection();
                        BlockTableRecord bd = (BlockTableRecord)tr.GetObject(bt[blockToFind], OpenMode.ForRead);

                        foreach (ObjectId adId in bd)
                        {
                            DBObject adObj = tr.GetObject(adId, OpenMode.ForRead);

                            // For each attribute definition we find...
                            AttributeDefinition ad = adObj as AttributeDefinition;

                            if (ad != null)
                            {
                                // ... we add its name to the list
                                colNames.Add(ad.Tag);
                            }
                        }

                        if (colNames.Count == 0)
                        {
                            ed.WriteMessage("\nThe block " + blockToFind + " contains no attribute definitions.");
                        }
                        else
                        {
                            // Ask the user for the insertion point
                            // and then create the table
                            PromptPointResult ppr = ed.GetPoint("\nEnter table insertion point: ");

                            if (ppr.Status == PromptStatus.OK)
                            {
                                Table tb = new Table();
                                tb.TableStyle = db.Tablestyle;
                                tb.NumRows = 1;
                                tb.NumColumns = colNames.Count;
                                tb.SetRowHeight(rowHeight);
                                tb.SetColumnWidth(colWidth);
                                tb.Position = ppr.Value;

                                // Let's add our column headings
                                for (int i = 0; i < colNames.Count; i++)
                                {
                                    SetCellText(tb, 0, i, colNames[i]);
                                }

                                // Now let's search for instances of
                                // our block in the modelspace
                                BlockTableRecord ms = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForRead);

                                int rowNum = 1;

                                foreach (ObjectId objId in ms)
                                {
                                    DBObject obj = tr.GetObject(objId, OpenMode.ForRead);
                                    BlockReference br = obj as BlockReference;

                                    if (br != null)
                                    {
                                        BlockTableRecord btr = (BlockTableRecord)tr.GetObject(br.BlockTableRecord, OpenMode.ForRead);

                                        using (btr)
                                        {
                                            if (btr.Name.ToUpper() == blockToFind)
                                            {
                                                // We have found one of our blocks,
                                                // so add a row for it in the table

                                                tb.InsertRows(rowNum, rowHeight, 1);

                                                // Assume that the attribute refs
                                                // follow the same order as the
                                                // attribute defs in the block

                                                int attNum = 0;

                                                foreach (ObjectId arId in br.AttributeCollection)
                                                {
                                                    DBObject arObj = tr.GetObject(arId, OpenMode.ForRead);
                                                    AttributeReference ar = arObj as AttributeReference;

                                                    if (ar != null)
                                                    {
                                                        // Embed or link the values
                                                        string strCell;

                                                        if (embed)
                                                        {
                                                            strCell = ar.TextString;
                                                        }
                                                        else
                                                        {
                                                            string strArId = arId.ToString();
                                                            strArId = strArId.Trim(new char[] { '(', ')' });
                                                            strCell = "%<\\AcObjProp Object(" + "%<\\_ObjId " + strArId + ">%).TextString>%";
                                                        }

                                                        SetCellText(tb, rowNum, attNum, strCell);
                                                    }
                                                    attNum++;
                                                }
                                                rowNum++;
                                            }
                                        }
                                    }
                                }
                                tb.GenerateLayout();

                                ms.UpgradeOpen();
                                ms.AppendEntity(tb);
                                tr.AddNewlyCreatedDBObject(tb, true);
                                tr.Commit();
                            }
                        }
                    }
                }
            }
        }
```
