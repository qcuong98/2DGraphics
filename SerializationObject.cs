using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics2D
{
    public class SerializationObject
    {
        public int nLayer;
        public Layer[] myLayers;
        public int curLayer;

        public SerializationObject()
        {
            nLayer = 0;
            myLayers = new Layer[0];
            curLayer = -1;
        }

        public SerializationObject(int n, Layer[] layers, int cur)
        {
            nLayer = n;
            myLayers = new Layer[nLayer];
            for (int i = 0; i < n; ++i)
                myLayers[i] = layers[i];
            curLayer = cur;
        }
    }
}
