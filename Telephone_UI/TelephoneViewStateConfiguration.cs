using System;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace Telephone_UI
{
    /// <summary>
    /// Class holding view states
    /// </summary>
    public class TelephoneViewStateConfiguration : IViewStateConfiguration
    {
        public Dictionary<string, object> ViewStates { get; set; }
        public string[] ViewStateList { get; set; }
        public string DefaultViewState
        {
            get
            {
                foreach (var source in ViewStates.Values.Cast<TelephoneViewState>().Where(item => item.IsDefaultViewState))
                {
                    return source.Name;
                }
                throw new Exception("Missing default view state");
            }
        }

        public TelephoneViewStateConfiguration()
        {
            InitViewStates();

        }

        private void InitViewStates()
        {
            ViewStates = new Dictionary<string, object>
            {
                { "ViewPhoneIdle",new TelephoneViewState("ViewPhoneIdle",false,false,true,true)},
                { "ViewPhoneRings",new TelephoneViewState("ViewPhoneRings",true,false,false)},
                { "ViewTalking",new TelephoneViewState("ViewTalking",false,true,false)},
            };

            ViewStateList = new[] { "ViewPhoneIdle", "ViewPhoneRings", "ViewTalking" };
        }
    }
}


