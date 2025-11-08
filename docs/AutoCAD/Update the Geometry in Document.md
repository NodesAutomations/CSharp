- Many of the actions you perform through the AutoCAD .NET API modify what is displayed in the drawing area. Not all of these actions immediately update the display of the drawing. This is designed so you can make several changes to the drawing without waiting for the display to be updated after every single action. Instead, you can bundle your actions together and make a single call to update the display when you have finished.
- The methods that will update the display are UpdateScreen (Application and Editor objects) and Regen (Editor object).
- The UpdateScreen method redraws the application or document windows. The Regen method regenerates the graphical objects in the drawing window, and recomputes the screen coordinates and view resolution for all objects. It also re-indexes the drawing database for optimum display and object selection performance.

```csharp
// Redraw the drawing
Application.UpdateScreen();
Application.DocumentManager.MdiActiveDocument.Editor.UpdateScreen();
 
// Regenerate the drawing
Application.DocumentManager.MdiActiveDocument.Editor.Regen();
```
