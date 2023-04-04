using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using System;
using CustomDialogs;

namespace CustomDialogs
{
  public class Commands
  {
    [CommandMethod("vt",CommandFlags.UsePickSet)]
    public void ViewType()
    {
      Editor ed =
        Application.DocumentManager.MdiActiveDocument.Editor;

      TypeViewerForm tvf = new TypeViewerForm();
      PromptSelectionResult psr =
        ed.GetSelection();
      if (psr.Value.Count > 0)
      {
        ObjectId selId = psr.Value[0].ObjectId;
        tvf.SetObjectId(selId);
      }
      if (psr.Value.Count > 1)
      {
        ed.WriteMessage(
          "\nMore than one object was selected: only using the first.\n"
        );
      }
      Application.ShowModalDialog(null, tvf, false);
    }
  }
}