using System.Collections.Generic;

namespace Common
{
    public interface IViewStateConfiguration
    {
        Dictionary<string, object> ViewStates { get; set; }

        string[] ViewStateList { get; set; }

        string DefaultViewState { get;  }
    }
}