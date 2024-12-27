/*
DEMO ONLY
NOT FULL CODE BASE
THIS IS TO AVOID PIRACY AS THIS IS A COMMERCIAL APP.
*/

void CalculatePresureAltitudeInternal()
        {

            string IndAltInput = ScreenLine2UserInputString;
            string inHgInput = ScreenLine3UserInputString;

            double IndAlt;
            double inHg;
            double AltCorr;
            double PressAlt;

            if (IndAltInput == "--" || inHgInput == "--")
            {
                Debug.Log("Made it here");
                Line10Text.color = Color.red;
                ScreenLine10CalculatedAnswer = "ERROR / Input Field Blank";
            }
            else
            {
                IndAlt = double.Parse(IndAltInput);
                inHg = double.Parse(inHgInput);

                if (IndAlt < 0 || IndAlt > 100000 || (AltimeterSettingUnits == " inHg" && (inHg < 18 || inHg > 41)) || (AltimeterSettingUnits == " mb(hPA)" && (inHg < 609 || inHg > 1390)))
                {
                    ScreenLine10CalculatedAnswer = "ERROR / Allowable Range Exceeded";
                    Line10Text.color = Color.red;
                }
                else
                {
                    if (AltimeterSettingUnits == " mb(hPA)")
                    {
                        //convert mb to inhg
                        inHg = inHg * 0.0295301;
                    }
                    if (AltitudeSettingUnits == " Meters")
                    {
                        //convert meters to feet
                        IndAlt = IndAlt * 3.28084;
                    }

                    //pressure altitude calcultion
                    AltCorr = 145442.2 * (1 - (System.Math.Pow((inHg / 29.92126), 0.190261)));
                    PressAlt = IndAlt + AltCorr;

                    if (AltitudeSettingUnits == " Meters")
                    {
                        //convert back to meters couse previous callc in feet, player picked meters
                        PressAlt = PressAlt * 0.3048;
                    }

                    ScreenLine7CalculatedAnswer = (System.Math.Round(PressAlt * 10) / 10).ToString();


                    Line10Text.color = Color.green;
                    ScreenLine10CalculatedAnswer = "Calculation Executed OK";
                }
            }

        }

