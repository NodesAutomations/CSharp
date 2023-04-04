using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CustomDialogs
{
  public partial class TypeViewerForm : Form
  {
    public TypeViewerForm()
    {
      InitializeComponent();
    }

    public void SetObjectText(string text)
    {
      typeTextBox.Text = text;
    }

    public void SetObjectId(ObjectId id)
    {
      if (id == ObjectId.Null)
      {
        SetObjectText("");
      }
      else
      {
        Document doc =
          Autodesk.AutoCAD.ApplicationServices.
            Application.DocumentManager.MdiActiveDocument;
        Transaction tr =
          doc.TransactionManager.StartTransaction();
        using (tr)
        {
          DBObject obj = tr.GetObject(id, OpenMode.ForRead);
          SetObjectText(obj.GetType().ToString());
          tr.Commit();
        }
      }
    }
    private void closeButton_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void browseButton_Click(object sender, EventArgs e)
    {
      DocumentCollection dm =
        Autodesk.AutoCAD.ApplicationServices.
          Application.DocumentManager;
      Editor ed =
        dm.MdiActiveDocument.Editor;

      Hide();
      PromptEntityResult per =
        ed.GetEntity("\nSelect entity: ");
      if (per.Status == PromptStatus.OK)
      {
        SetObjectId(per.ObjectId);
      }
      else
      {
        SetObjectId(ObjectId.Null);
      }
      Show();
    }
  }
}