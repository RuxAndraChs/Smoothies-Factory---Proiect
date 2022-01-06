using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smoothies_Factory
{
    class Smoothies
    {

        

        private SmoothiesType mFlavor;

        public SmoothiesType Flavor
        {
            get
            {
                return mFlavor;
            }
            set
            {
                mFlavor = value;
            }
        }

        private float mPrice;
        public float Price
        {
            get
            {
                return mPrice;
            }
            set
            {
                mPrice = value;
            }
        }
        public Smoothies(SmoothiesType aFlavor)
        {
            mFlavor = aFlavor;
        }
    }

    public enum SmoothiesType
    {
        Banana_Strawberry,
        Orange_Apple,
        Mango_Peach,
        Mocha_Coffe,
        Purple_Rain,
        Chia_Cleanse,
        Power_UP,
        Mint_Chocolate,
        BlueBerry_Madness

    }
}
