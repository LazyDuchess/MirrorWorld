using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
internal static class AssetBundleBuilder
{
    [MenuItem("MirrorWorld/Build Asset Bundles")]
    private static void BuildAssetBundles()
    {
        Directory.CreateDirectory("Build");
        BuildPipeline.BuildAssetBundles("Build", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
    }
}
