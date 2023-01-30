using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPI_CountColomnInModel
{
    [Transaction(TransactionMode.Manual)]

    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application; // -> Revit
            UIDocument uidoc = uiapp.ActiveUIDocument; // текущий документ
            Document doc = uidoc.Document; // обращение к безе данных текужего документа

            List<FamilyInstance> familyInstances = new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_StructuralColumns)
                .WhereElementIsNotElementType()
                .Cast<FamilyInstance>()
                .ToList();
            TaskDialog.Show("Colomn count", familyInstances.Count.ToString());

            return Result.Succeeded;
        }
    }
}
