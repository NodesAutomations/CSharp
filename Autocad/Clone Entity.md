### Regular Clone
```csharp
[CommandMethod("CloneLeaderWithMText")]
public void CloneLeaderWithMText()
{
    Document doc = Application.DocumentManager.MdiActiveDocument;
    Database db = doc.Database;
    Editor ed = doc.Editor;

    using (Transaction tr = db.TransactionManager.StartTransaction())
    {
        // Prompt for the leader to clone
        PromptEntityOptions peo = new PromptEntityOptions("\nSelect a leader to clone: ");
        peo.SetRejectMessage("\nSelected entity is not a leader.");
        peo.AddAllowedClass(typeof(Leader), true);
        PromptEntityResult per = ed.GetEntity(peo);

        if (per.Status != PromptStatus.OK)
            return;

        Leader originalLeader = tr.GetObject(per.ObjectId, OpenMode.ForRead) as Leader;

        if (originalLeader == null)
            return;

        // Clone the leader
        Leader clonedLeader = originalLeader.Clone() as Leader;

        if (clonedLeader == null)
            return;

        // Add the cloned leader to the database
        BlockTableRecord btr = tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite) as BlockTableRecord;
        btr.AppendEntity(clonedLeader);
        tr.AddNewlyCreatedDBObject(clonedLeader, true);

        // Clone the associated MText
        MText originalMText = tr.GetObject(originalLeader.Annotation, OpenMode.ForRead) as MText;

        if (originalMText != null)
        {
            MText clonedMText = originalMText.Clone() as MText;

            if (clonedMText != null)
            {
                btr.AppendEntity(clonedMText);
                tr.AddNewlyCreatedDBObject(clonedMText, true);

                // Associate the cloned MText with the cloned leader
                clonedLeader.Annotation = clonedMText.ObjectId;

                clonedLeader.TransformBy(Matrix3d.Displacement(new Vector3d(1000, 500, 0)));
                clonedMText.TransformBy(Matrix3d.Displacement(new Vector3d(1000, 500, 0)));
            }
        }

        tr.Commit();
    }
}
```

### Deep Clone
```csharp
[CommandMethod("CloneLeaderWithMText")]
public void CloneLeaderWithMText()
{
    var doc = Application.DocumentManager.MdiActiveDocument;
    var db = doc.Database;
    var ed = doc.Editor;

    // Prompt for the leader to clone
    var peo = new PromptEntityOptions("\nSelect a leader to clone: ");
    peo.SetRejectMessage("\nSelected entity is not a leader.");
    peo.AddAllowedClass(typeof(Leader), true);
    var per = ed.GetEntity(peo);
    if (per.Status != PromptStatus.OK)
        return;

    using (var tr = db.TransactionManager.StartTransaction())
    {
        var leader = (Leader)tr.GetObject(per.ObjectId, OpenMode.ForRead);

        // Clone the leader and its annotation (if any)
        var ids = new ObjectIdCollection { leader.ObjectId };
        if (!leader.Annotation.IsNull)
            ids.Add(leader.Annotation);
        var mapping = new IdMapping();
        db.DeepCloneObjects(ids, leader.OwnerId, mapping, false);

        // Displace the cloned entitie(s)
        var displace = Matrix3d.Displacement(new Vector3d(1000.0, 500.0, 0.0));
        foreach (IdPair pair in mapping)
        {
            if (pair.IsCloned && pair.IsPrimary)
            {
                var entity = (Entity)tr.GetObject(pair.Value, OpenMode.ForWrite);
                entity.TransformBy(displace);
            }
        }
        tr.Commit();
    }
}
```