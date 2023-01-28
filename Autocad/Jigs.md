### Overview
- Jig basically allows you to preview something before it is actually drawn in the model space – and moreover, it allows you to dynamically change the end result of what is drawn, according to certain inputs.
- The circle jig is a jig that is built by the boffins at AutoDesk. You too can make your own jigs. Perhaps more complex ones.

### Text Jig sample
```csharp
[CommandMethod("Test")]
static public void QuickText()
{
    //Get String input
    PromptStringOptions promptStringOptions = new PromptStringOptions("\nEnter text string");
    promptStringOptions.AllowSpaces = true;
    PromptResult promptResult = ActiveUtil.Editor.GetString(promptStringOptions);

    if (promptResult.Status != PromptStatus.OK)
    {
        return;
    }

    using (Transaction transaction = ActiveUtil.Document.TransactionManager.StartTransaction())
    {
        BlockTableRecord activeSpaceBlockTableRecord = transaction.GetObject(ActiveUtil.Database.CurrentSpaceId, OpenMode.ForWrite) as BlockTableRecord;

        // Create a single-line text object
        using (DBText text = new DBText())
        {
            text.Height = 5;
            text.TextString = promptResult.StringResult; ;

            // We'll add the text to the database before jigging
            // it - this allows alignment adjustments to be reflected
            activeSpaceBlockTableRecord.AppendEntity(text);
            transaction.AddNewlyCreatedDBObject(text, true);

            // Create our jig
            TextPlacementJig textPlacementJig = new TextPlacementJig(transaction, ActiveUtil.Database, text);

            // Loop as we run our jig, as we may have keywords
            PromptStatus stat = PromptStatus.Keyword;

            while (stat == PromptStatus.Keyword)
            {
                PromptResult res = ActiveUtil.Editor.Drag(textPlacementJig);

                stat = res.Status;

                if (stat != PromptStatus.OK && stat != PromptStatus.Keyword)
                {
                    return;
                }
            }
        }

        transaction.Commit();
    }
}

private class TextPlacementJig : EntityJig
{
    // Declare some internal state

    private Database _db;

    private Transaction _tr;

    private Point3d _position;

    public TextPlacementJig(Transaction tr, Database db, Entity ent) : base(ent)
    {
        _db = db;
        _tr = tr;
    }

    protected override SamplerStatus Sampler(JigPrompts jp)
    {
        // We acquire a point but with keywords
        JigPromptPointOptions po = new JigPromptPointOptions("\nPosition of text");

        po.UserInputControls = (UserInputControls.Accept3dCoordinates | UserInputControls.NullResponseAccepted | UserInputControls.NoNegativeResponseAccepted | UserInputControls.GovernedByOrthoMode);

        PromptPointResult ppr = jp.AcquirePoint(po);

        if (ppr.Status == PromptStatus.OK)
        {
            // Check if it has changed or not (reduces flicker)
            if (_position.DistanceTo(ppr.Value) < Tolerance.Global.EqualPoint)
            {
                return SamplerStatus.NoChange;
            }

            _position = ppr.Value;
            return SamplerStatus.OK;
        }

        return SamplerStatus.Cancel;
    }

    protected override bool Update()
    {
        // Set properties on our text object
        DBText txt = (DBText)Entity;
        txt.Position = _position;
        return true;
    }
}
```
