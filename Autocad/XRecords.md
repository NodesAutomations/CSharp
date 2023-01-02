### Overview
- Code to Store Data

### Set XRecord in Object
```csharpprivate static void SetXRecordInObject(ObjectId id, string key, ResultBuffer rb)
        {
            try
            {
                using (DocumentLock acLckDoc =
                Application.DocumentManager.MdiActiveDocument.LockDocument())
                {
                    Database db = Application.DocumentManager.MdiActiveDocument.Database;
                    using (Transaction tr = db.TransactionManager.StartTransaction())
                    {
                        using (Entity ent = tr.GetObject(id, OpenMode.ForWrite) as Entity)
                        {
                            if (ent != null)
                            {
                                if (ent.ExtensionDictionary == ObjectId.Null)
                                {
                                    ent.CreateExtensionDictionary();
                                }
                                using (DBDictionary xDict =
                                (DBDictionary)tr.GetObject(ent.ExtensionDictionary, OpenMode.ForWrite))
                                {
                                    using (Xrecord xRec = new Xrecord())
                                    {
                                        xRec.Data = rb;
                                        try
                                        {
                                            xDict.Remove(key);
                                        }
                                        catch (System.Exception) { }
                                        xDict.SetAt(key, xRec);
                                        tr.AddNewlyCreatedDBObject(xRec, true);
                                    }
                                }
                            }
                        }
                        tr.Commit();
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
```

### Get XRecords from Object
```

        private static List<object> GetXRecordFromObject(ObjectId id, string key)
        {
            List<object> returnValue = new List<object>();
            try
            {
                using (DocumentLock acLckDoc =
                Application.DocumentManager.MdiActiveDocument.LockDocument())
                {
                    Database db = Application.DocumentManager.MdiActiveDocument.Database;
                    using (Transaction tr = db.TransactionManager.StartTransaction())
                    {
                        using (Entity ent = tr.GetObject(id, OpenMode.ForRead, false) as Entity)
                        {
                            if (ent.ExtensionDictionary == ObjectId.Null) { return returnValue; }
                            try
                            {
                                using (DBDictionary xDict =
                                (DBDictionary)tr.GetObject(ent.ExtensionDictionary, OpenMode.ForRead, false))
                                {
                                    using (Xrecord xRec = (Xrecord)tr.GetObject(xDict.GetAt(key),
                                    OpenMode.ForRead, false))
                                    {
                                        TypedValue[] xRecData = xRec.Data.AsArray();
                                        foreach (TypedValue tv in xRecData) { returnValue.Add(tv.Value); }
                                    }
                                }
                            }
                            catch (System.Exception) { }
                        }
                        tr.Commit();
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            return returnValue;
        }
```
