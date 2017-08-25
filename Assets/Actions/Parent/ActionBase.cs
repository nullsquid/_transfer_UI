using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionBase {
    public delegate void onActionComplete();
    public event onActionComplete OnComplete;

    protected string _actionName;
    protected bool _isActive;
    protected List<string> _args;
    public List<string> Args
    {
        get
        {
            return _args;
        }
        set
        {
            _args = value;
        }
    }

    public string ActionName {
        get
        {
            return _actionName;
        }
        set
        {
            _actionName = value;
        }
    }

	public virtual void ExecuteActionLogic() {

    }
}
