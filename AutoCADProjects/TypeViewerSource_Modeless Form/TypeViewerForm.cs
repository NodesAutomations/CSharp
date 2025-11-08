using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using System;
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
                Document doc = Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.MdiActiveDocument;
                using (DocumentLock docLock = doc.LockDocument())
                {
                    using (Transaction tr = doc.TransactionManager.StartTransaction())
                    {
                        DBObject obj = tr.GetObject(id, OpenMode.ForRead);
                        SetObjectText(obj.GetType().ToString());
                        tr.Commit();
                    }
                }
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}