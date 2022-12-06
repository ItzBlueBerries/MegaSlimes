using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MegaSlimes
{
    internal class Bundles
    {
        internal static AssetBundle evo_structures = AssetBundle.LoadFromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream(typeof(Main), "Bundles.evo_structures"));

        internal static AssetBundle external_models = AssetBundle.LoadFromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream(typeof(Main), "Bundles.external_models"));
    }
}
