using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Deadlands_App
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private void BtnHitLocation_Clicked(object sender, EventArgs e)
        {
            RollHitLocation(0);
        }

        private void BtnHitLocationPlus2_Clicked(object sender, EventArgs e)
        {
            RollHitLocation(2);
        }
        private void BtnHitLocationPlus4_Clicked(object sender, EventArgs e)
        {
            RollHitLocation(4);
        }
        private void BtnHitLocationPlus6_Clicked(object sender, EventArgs e)
        {
            RollHitLocation(6);
        }
        private void BtnHitLocationMinus2_Clicked(object sender, EventArgs e)
        {
            RollHitLocation(-2);
        }
        private void RollHitLocation(int modifier)
        {
            Random rnd = new Random();
            int result = rnd.Next(1, 21); // creates a number between 1 and 20
            result += modifier;
            if (result > 20)
            {
                result = 20;
            }
            if (result < 1)
            {
                result = 1;
            }
            lblResult.Text = "Result: " + result;
            int evenOdd = rnd.Next(1, 3);
            lblLocation.Text = GetLocation(result, 0, evenOdd);
            lbl1Raise.Text = GetLocation(result, 1, evenOdd);
            lbl2Raises.Text = GetLocation(result, 2, evenOdd);
            lbl3Raises.Text = GetLocation(result, 3, evenOdd);
        }

        private string GetLocation(int result, int raises, int evenOdd)
        {
            if (raises == 0)
            {
                return ChartLookup(result, evenOdd);
            }
            else 
            {
                if(result + raises > 20)
                {
                    return ChartLookup(result - raises, evenOdd);
                }
                else if (result - raises < 1)
                {
                    return ChartLookup(result + raises, evenOdd);
                }
                else
                {
                    return ChartLookup(result - raises, evenOdd) + " / " + ChartLookup(result + raises, evenOdd); 
                }
            }
        }

        private string ChartLookup(int result, int evenOdd)
        {
            switch (result)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    if (evenOdd == 1)
                    {
                        return "Left Leg";
                    }
                    else
                    {
                        return "Right Leg";
                    }
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    return "Guts";
                case 10:
                    return "Gizzards (+1 Die)";
                case 11:
                case 12:
                case 13:
                case 14:
                    if (evenOdd == 1)
                    {
                        return "Left Arm";
                    }
                    else
                    {
                        return "Right Arm";
                    }
                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                    return "Guts";
                case 20:
                    return "Head (+2 Dice)";
            }
            return string.Empty;
        }
    }
}
