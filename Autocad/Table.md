
### Chat GPT code to generate simple table
```csharp
 [CommandMethod("GENERATETABLE")]
        public void GenerateTable()
        {
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;
            Editor acEd = acDoc.Editor;

            // Start a transaction
            using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
            {
                // Open the Block table for read
                BlockTable acBlkTbl;
                acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId, OpenMode.ForRead) as BlockTable;

                // Open the Block table record Model space for write
                BlockTableRecord acBlkTblRec;
                acBlkTblRec = acTrans.GetObject(acBlkTbl[BlockTableRecord.ModelSpace],
                                                 OpenMode.ForWrite) as BlockTableRecord;

                // Create a new table object
                Table acTable = new Table();
                acTable.TableStyle = acCurDb.Tablestyle;
                acTable.NumRows = 5;
                acTable.NumColumns = 4;

                // Set the data in the table
                acTable.Cells[0, 0].TextString = "Product ID";
                acTable.Cells[0, 1].TextString = "Product Name";
                acTable.Cells[0, 2].TextString = "Unit Price";
                acTable.Cells[0, 3].TextString = "Units In Stock";
                acTable.Cells[1, 0].TextString = "P001";
                acTable.Cells[1, 1].TextString = "Product 1";
                acTable.Cells[1, 2].TextString = "$10.00";
                acTable.Cells[1, 3].TextString = "50";
                acTable.Cells[2, 0].TextString = "P002";
                acTable.Cells[2, 1].TextString = "Product 2";
                acTable.Cells[2, 2].TextString = "$20.00";
                acTable.Cells[2, 3].TextString = "100";
                acTable.Cells[3, 0].TextString = "P003";
                acTable.Cells[3, 1].TextString = "Product 3";
                acTable.Cells[3, 2].TextString = "$30.00";
                acTable.Cells[3, 3].TextString = "200";
                acTable.Cells[4, 0].TextString = "P004";
                acTable.Cells[4, 1].TextString = "Product 4";
                acTable.Cells[4, 2].TextString = "$40.00";
                acTable.Cells[4, 3].TextString = "300";

                // Append the table to the modelspace
                acBlkTblRec.AppendEntity(acTable);
                acTrans.AddNewlyCreatedDBObject(acTable, true);

                // Calculate the table height and width
                double dTableHeight = acTable.Rows[0].Height + acTable.Rows[1].Height +
                                      acTable.Rows[2].Height + acTable.Rows[3].Height +
                                      acTable.Rows[4].Height;
                double dTableWidth = acTable.Columns[0].Width + acTable.Columns[1].Width +
                                     acTable.Columns[2].Width + acTable.Columns[3].Width;

                // Set the insertion point for the table
                Point3d insertPoint = new Point3d(0, 0, 0);
                acTable.Position = insertPoint;

                // Commit the changes and dispose of the transaction
                acTrans.Commit();
            }
```

### Code to insert Table of Blocks
ref : https://www.keanw.com/2015/07/creating-a-table-of-autocad-blocks-using-net.html
```csharp
        private const double rowHeight = 3.0, colWidth = 5.0;
        private const double textHeight = rowHeight * 0.25;
        
        [CommandMethod("CBT")]
        static public void CreateBlockTable()
        {
            var doc = Application.DocumentManager.MdiActiveDocument;

            if (doc == null)
                return;

            var db = doc.Database;

            var ed = doc.Editor;

            var pr = ed.GetPoint("\nEnter table insertion point");

            if (pr.Status != PromptStatus.OK)
                return;

            using (var tr = doc.TransactionManager.StartTransaction())
            {
                var bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead);

                // Create the table, set its style and default row/column size

                var tb = new Table();
                tb.TableStyle = db.Tablestyle;
                tb.SetRowHeight(rowHeight);
                tb.SetColumnWidth(colWidth);
                tb.Position = pr.Value;

                // Set the header cell
                var head = tb.Cells[0, 0];
                head.Value = "Blocks";
                head.Alignment = CellAlignment.MiddleCenter;
                head.TextHeight = textHeight;

                // Insert an additional column
                tb.InsertColumns(0, colWidth, 1);

                // Loop through the blocks in the drawing, creating rows
                foreach (var id in bt)
                {
                    var btr = (BlockTableRecord)tr.GetObject(id, OpenMode.ForRead);

                    // Only care about user-insertable blocks

                    if (!btr.IsLayout && !btr.IsAnonymous)
                    {
                        // Add a row
                        tb.InsertRows(tb.Rows.Count, rowHeight, 1);

                        var rowIdx = tb.Rows.Count - 1;

                        // The first cell will hold the block name
                        var first = tb.Cells[rowIdx, 0];
                        first.Value = btr.Name;
                        first.Alignment = CellAlignment.MiddleCenter;
                        first.TextHeight = textHeight;

                        // The second will contain a thumbnail of the block
                        var second = tb.Cells[rowIdx, 1];
                        second.BlockTableRecordId = id;
                    }
                }

                // Now we add the table to the current space
                var sp = (BlockTableRecord)tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite);
                sp.AppendEntity(tb);

                // And to the transaction, which we then commit
                tr.AddNewlyCreatedDBObject(tb, true);
                tr.Commit();
            }
        }
```
```csharp
[CommandMethod("CRT")]
        static public void CreateTable()
        {
            PromptPointResult pr = ActiveUtil.Editor.GetPoint("\nEnter table insertion point: ");

            if (pr.Status == PromptStatus.OK)
            {
                using (Transaction tr = ActiveUtil.Document.TransactionManager.StartTransaction())
                {
                    BlockTable bt = (BlockTable)tr.GetObject(ActiveUtil.Document.Database.BlockTableId, OpenMode.ForRead);

                    Table tb = new Table();
                    tb.TableStyle = ActiveUtil.Database.Tablestyle;
                    tb.NumRows = 5;

                    // Added an additional column for the block image
                    tb.NumColumns = 4;
                    tb.SetRowHeight(3);
                    tb.SetColumnWidth(15);
                    tb.Position = pr.Value;

                    // Create a 2-dimensional array
                    // of our table contents
                    string[,] str = new string[5, 3];

                    str[0, 0] = "Part No.";
                    str[0, 1] = "Name ";
                    str[0, 2] = "Material ";
                    str[1, 0] = "1876-1";
                    str[1, 1] = "Pole";
                    str[1, 2] = "Perspex";
                    str[2, 0] = "0985-4";
                    str[2, 1] = "Mark";
                    str[2, 2] = "Steel";
                    str[3, 0] = "3476-K";
                    str[3, 1] = "Ribbon";
                    str[3, 2] = "Ceramic";
                    str[4, 0] = "8734-3";
                    str[4, 1] = "Master";
                    str[4, 2] = "Mostly water";

                    // Use a nested loop to add and format each cell
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            tb.SetTextHeight(i, j, 1);
                            tb.SetTextString(i, j, str[i, j]);
                            tb.SetAlignment(i, j, CellAlignment.MiddleCenter);
                        }

                        // If a block definition exists for a block of our
                        // "name" field, then let's set it in the 4th column
                        if (bt.Has(str[i, 1]))
                        {
                            tb.SetBlockTableRecordId(i, 3, bt[str[i, 1]], true);
                        }
                    }
                    tb.GenerateLayout();

                    BlockTableRecord btr = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);
                    btr.AppendEntity(tb);
                    tr.AddNewlyCreatedDBObject(tb, true);
                    tr.Commit();
                }
            }
        }
```
