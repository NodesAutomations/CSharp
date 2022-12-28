### Code to Get Atrributes from Block
reference : https://forums.autodesk.com/t5/net/get-attribute-tags-from-block/m-p/8596731#M61531
```csharp
BlockReference br = acTrans.GetObject(acSSObj.ObjectId, OpenMode.ForRead) as BlockReference;
AttributeCollection attCol = br.AttributeCollection;
foreach (ObjectId attId in attCol)
{
    AttributeReference attRef = (AttributeReference)acTrans.GetObject(attId, OpenMode.ForRead);

    string tag = attRef.Tag;
    string value = attRef.TextString;
}
```
