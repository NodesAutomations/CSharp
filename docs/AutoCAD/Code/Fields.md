### Overview
- Ref : https://www.keanw.com/2007/06/embedding_field.html
- Fields are very cool objects: they allow you to access a very wide array of information and embed them inside textual objects in AutoCAD
- we can use it with tables, text, Mtext, Attributes.
- A field is an object, but can be defined by a text string containing angled-brackets etc. that AutoCAD interprets and regenerates at different times during execution (on regen, on drawing load etc. - check out the FIELDEVAL system variable for more details on that). The simplest way to create field objects in your applications is simply to embed a correctly formatted string: all being well, AutoCAD will understand it to represent a field and will create the corresponding object behind the scenes. Easy! :-)

Here's an example of a string we can embed directly in the table cell to do this:
```
%<\AcObjProp Object(%<\_ObjId 2130399456>%).IsDynamicBlock>%
```
Breaking it down:
- The first and last two characters tell AutoCAD the extents of the field definition
- The AcObjProp string tells AutoCAD we're dealing with an object property
- The Object string tells AutoCAD we're about to refer to an object
- The _ObjId field points to an object by it's internal Object ID
- The property we want to access is IsDynamicBlock
