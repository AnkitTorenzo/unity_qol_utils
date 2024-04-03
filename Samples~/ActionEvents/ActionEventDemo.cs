using QOL;
using UnityEngine;

public class ActionEventDemo : MonoBehaviour
{
    private ActionEvent aEvent;

    #region Unity Callbacks
    private void Awake()
    {
        aEvent += () =>                                     //Adding a lemda expression using += operator.
        {
            Debug.Log($"Hello how are you?");
        };

        aEvent.AddListener(() =>                            //Adding a listener using AddListener() method.
        {
            Debug.Log($"Another Subscription");
        });
        aEvent.AddListener(Subscription);                   //Adding a method as a listener using AddListener().
    }
    #endregion

    #region Public Methods

    #endregion

    #region Private Methods
    [ContextMenu("Call Action Events")]
    private void CallActionEvent()
    {
        aEvent.Invoke();                                    // Invoking the event using the Invoke Method. Since it is a struct wrapper of a build in delegate 'Action'.
                                                            // We can not invoke ActionEvents as a regular method, as we can do with 'Action' or any other delegates.
                                                            // Since ActionEvent is a struct no need to explicitly assigning a value in it, nor you have any need for a null check.
    }

    private void Subscription()
    {
        aEvent.RemoveListener(Subscription);
    }
    #endregion

    #region Properties

    #endregion
}
