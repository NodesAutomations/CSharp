### Overview
- Code to Store Data

### Set XRecord in Object
```csharp
private static void SetXRecordInObject(ObjectId id, string key, ResultBuffer rb)
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
```csharp
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

### Sample Code to Store Text in object
```csharp
/// <summary>
        /// Save a textstring in the ExtensionDictionary of an object
        /// </summary>
        public static void SetObjXRecordText(ObjectId id, string key, string value)
        {
            using (ResultBuffer resBuf = new ResultBuffer(new TypedValue((int)DxfCode.Text, value)))
            {
                SetXRecordInObject(id, key, resBuf);
            }
        }
```
```csharp
 /// <summary>
        /// Read a string from the ExtensionDictionary of an object
        /// </summary>
        public static string GetObjXRecordText(ObjectId id, string key)
        {
            string returnValue = string.Empty;
            List<object> records = GetXRecordFromObject(id, key);
            if (records.Count > 0) { returnValue = Convert.ToString(records[records.Count - 1]); }
            return returnValue;
        }
```

### Code to Store Interger in Object
```csharp
 /// <summary>
        /// Save an integer in the ExtensionDictionary of an object
        /// </summary>
        public static void SetObjXRecordInt32(ObjectId id, string key, int value)
        {
            using (ResultBuffer resBuf = new ResultBuffer(new TypedValue((int)DxfCode.Int32, value)))
            {
                SetXRecordInObject(id, key, resBuf);
            }
        }
```
```csharp

        /// <summary>
        /// Read an integer from the ExtensionDictionary of an object
        /// </summary>
        public static int GetObjXRecordInt32(ObjectId id, string key)
        {
            int returnValue = -1;
            List<object> records = GetXRecordFromObject(id, key);
            if (records.Count > 0) { returnValue = Convert.ToInt32(records[records.Count - 1]); }
            return returnValue;
        }
```
