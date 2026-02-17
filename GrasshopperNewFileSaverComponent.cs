using Grasshopper;
using Grasshopper.Kernel;
using Rhino;
using System;
using System.IO;
using System.Linq;

public class AutoSaveOnNewDoc : GH_AssemblyPriority
{
    public override GH_LoadingInstruction PriorityLoad()
    {
        Grasshopper.Instances.DocumentServer.DocumentAdded += DocumentServer_DocumentAdded;
        return GH_LoadingInstruction.Proceed;
    }

    private void DocumentServer_DocumentAdded(GH_DocumentServer sender, GH_Document doc)
    {
        try
        {
            // Only auto-save if the document has no file path yet (i.e., it's new)
            if (string.IsNullOrEmpty(doc.FilePath))
            {
                string folder = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "GrasshopperAutoSaves"
                );

                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                string filename = $"NewGHFile_{DateTime.Now:yyyyMMdd_HHmmss}.gh";
                string fullPath = Path.Combine(folder, filename);
                doc.FilePath = fullPath;
                var io = new GH_DocumentIO(doc);
                io.SaveQuiet(fullPath);
            }
        }
        catch (Exception ex)
        {
            RhinoApp.WriteLine("AutoSave error: " + ex.Message);
        }

    }
}