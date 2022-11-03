```csharp
private static void Main()
        {
            try
            {
                var dxfDoc = new DxfDocument();
                dxfDoc.Comments.RemoveAt(0);
                var layer = new Layer("Main")
                {
                    Color = AciColor.Red
                };
                dxfDoc.Layers.Add(layer);
                var lines = new List<Line>()
                {
                    new Line(new Vector2(0, 0), new Vector2(10, 0)){Layer=layer},
                    new Line(new Vector2(10, 0), new Vector2(10, 10)){Layer=layer},
                    new Line(new Vector2(10, 10), new Vector2(0, 10)){Layer=layer},
                    new Line(new Vector2(0, 10), new Vector2(0, 0)){Layer=layer}
                };
                dxfDoc.AddEntity(lines);
                dxfDoc.Save(@"C:\Users\Ryzen2600x\Downloads\sample.dxf");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Console.ReadLine();
            }
        }
```
