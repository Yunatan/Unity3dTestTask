using System.Collections;
using AssetBundles;
using UnityEngine;

namespace Assets.Scripts
{
    public class BookLoadingScript : MonoBehaviour {

        public string assetBundleName;
        public string bookAssetName;
        public string textureAssetName;

        private GameObject bookInstance;

        IEnumerator Start()
        {
            yield return StartCoroutine(Initialize());

            yield return StartCoroutine(InstantiateBookAsync(assetBundleName, bookAssetName));

            yield return StartCoroutine(ApplyTextureToBookAsync(assetBundleName, textureAssetName));
        }

        // Initialize the downloading url and AssetBundleManifest object.
        protected IEnumerator Initialize()
        {
            AssetBundleManager.SetDevelopmentAssetBundleServer();

            // Initialize AssetBundleManifest which loads the AssetBundleManifest object.
            var request = AssetBundleManager.Initialize();
            if (request != null)
                yield return StartCoroutine(request);
        }

        protected IEnumerator InstantiateBookAsync(string bundleName, string assetName)
        {
            // Load asset from assetBundle.
            var request = AssetBundleManager.LoadAssetAsync(bundleName, assetName, typeof(GameObject));
            if (request == null)
                yield break;
            yield return StartCoroutine(request);

            bookInstance = request.GetAsset<GameObject>();
            bookInstance.transform.Rotate(new Vector3(0, 0, 180));

            if (bookInstance != null)
                Instantiate(bookInstance);
        }

        protected IEnumerator ApplyTextureToBookAsync(string bundleName, string textureName)
        {
            // Load asset from assetBundle.
            var request = AssetBundleManager.LoadAssetAsync(bundleName, textureName, typeof(Texture));
            if (request == null)
                yield break;
            yield return StartCoroutine(request);

            var bookMaterial = bookInstance.GetComponent<MeshRenderer>().sharedMaterial;

            bookMaterial.mainTexture = request.GetAsset<Texture>();
        }

        public void ApplyTextureToBookAsync(string textureName)
        {
            StartCoroutine(ApplyTextureToBookAsync(assetBundleName, textureName));
        }
    }
}
