
namespace AndroidGoodiesExamples
{
	using System;
	using System.Collections;
	using System.IO;
	using System.Linq;
#if UNITY_ANDROID
	using DeadMosquito.AndroidGoodies.Internal;
	using DeadMosquito.AndroidGoodies;
#endif
	using JetBrains.Annotations;
	using UnityEngine;
	using UnityEngine.UI;

	public class OtherGoodiesTest : MonoBehaviour
	{
		public GameObject[] photos;
		private Texture2D imageTexture2D;

#if UNITY_ANDROID

		Texture2D _lastTakenScreenshot;

		string _imageFilePath;

		void Start()
		{
			
		}
		

		#region toast

		[UsedImplicitly]
		public void OnShortToastClick()
		{
			AGUIMisc.ShowToast("hello short!");
		}

		[UsedImplicitly]
		public void OnLongToastClick()
		{
			AGUIMisc.ShowToast("hello long!", AGUIMisc.ToastLength.Long);
		}

		#endregion

		#region maps

		[UsedImplicitly]
		public void OnOpenMapClick()
		{
			AGMaps.OpenMapLocation(47.6f, -122.3f, 9);
		}

		[UsedImplicitly]
		public void OnOpenMapLabelClick()
		{
			AGMaps.OpenMapLocationWithLabel(47.6f, -122.3f, "My Label");
		}

		[UsedImplicitly]
		public void OnOpenMapAddress()
		{
			AGMaps.OpenMapLocation("1st & Pike, Seattle");
		}

		#endregion


		[UsedImplicitly]
		public void OnPickGalleryImage()
		{
			// Whether to generate thumbnails
			var shouldGenerateThumbnails = true;

			// if image is larger it will be downscaled to the max size proportionally
			var imageResultSize = ImageResultSize.Max512;
			
				AGGallery.PickImageFromGallery(
				selectedImage =>
				{
					Clicks c = new Clicks();
					for (int i = 0; i <= c.cli; i++)
					{
						imageTexture2D = selectedImage.LoadTexture2D();

						string msg = string.Format("{0} was loaded from gallery with size {1}x{2}",
							selectedImage.OriginalPath, imageTexture2D.width, imageTexture2D.height);
						AGUIMisc.ShowToast(msg);
						Debug.Log(msg);
						//image.sprite = SpriteFromTex2D(imageTexture2D);
						Material material = photos[i].GetComponent<Renderer>().material;
						if (!material.shader.isSupported)
							material.shader = Shader.Find("Legacy Shaders/Diffuse");

						material.mainTexture = imageTexture2D;
					}

				},

				errorMessage => AGUIMisc.ShowToast("Cancelled picking image from gallery: " + errorMessage),
				imageResultSize, shouldGenerateThumbnails);

			
		}

#endif
	}
}