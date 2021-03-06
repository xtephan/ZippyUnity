using UnityEngine;
using System.Collections;

public class DepthImage : MonoBehaviour
{
    public IisuInputProvider IisuInput;
	public HandIisuInput Hand1;
	public HandIisuInput Hand2;

    private ImageConvertor _imageConvertor;

    public Texture2D DepthMap;
	
	public float NormalizedXCoordinate;
	public float NormalizedYCoordinate;
	public float NormalizedWidth;
	
	private float _heightWidthRatio;
	
	private float _timer;
	
    void Awake()
    {
        _imageConvertor = new ImageConvertor(160, 120);
		_timer = 0;
		_heightWidthRatio = 120f/160f;
    }
	
	/// <summary>
	/// We get the depth image from iisu, which is in a 16bit grey image format 
	/// The image is converted by the ImageConvertor class to a Unity image, and then applied to the 2D GUI texture
	/// </summary>	
    void Update()
    {
		//we update the depthmap 30fps
		if(_timer >= 0.0333f)
		{
			_timer = 0;
			
			if (DepthMap == null)
	        {
	            DepthMap = new Texture2D(160, 120, TextureFormat.ARGB32, false);
	       	}
			
			int handLabel1 = -1;
			int handLabel2 = -1;
			
			if(Hand1.Detected)
				handLabel1 = IisuInput.Hand1Label;
			if(Hand2.Detected)
				handLabel2 = IisuInput.Hand2Label;
			
			_imageConvertor.generateHandMask(IisuInput.DepthMap, IisuInput.LabelImage, ref DepthMap, handLabel1, handLabel2);
			
		}
		else
		{
			_timer += Time.deltaTime;
		}
    }

    void OnGUI()
    {
        if (DepthMap != null)
        {
            GUI.DrawTexture(new Rect(Screen.width * NormalizedXCoordinate + Screen.width * NormalizedWidth,
                                     Screen.height * NormalizedYCoordinate + Screen.width * NormalizedWidth * _heightWidthRatio,
                                     -Screen.width * NormalizedWidth,
                                     -Screen.width * NormalizedWidth * _heightWidthRatio), DepthMap);
        }
    }
}
