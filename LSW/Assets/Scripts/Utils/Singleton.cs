using Sirenix.OdinInspector;
using UnityEngine;

namespace Zombie {

    /// <summary>
    /// Be aware this will not prevent a non singleton constructor
    ///   such as `T myT = new T();`
    /// To prevent that, add `protected T () {}` to your singleton class.
    /// </summary>
    public abstract class Singleton<T> : SerializedMonoBehaviour where T : MonoBehaviour {

        #region Protected

        protected static T _instance;
        protected static object _lock = new object();

        #endregion

        #region Static

        public static T Instance {
            get {

       //         if(applicationIsQuitting) {
				   // Debug.LogWarning("[Singleton] Instance '"+ typeof(T) +
					  //  "' already destroyed on application quit." +
					  //  " Won't create again - returning null.");
				   // return null;
			    //}

                lock (_lock) {
                    if(!_instance) {
                        _instance = (T)FindObjectOfType(typeof(T));

                        //if(FindObjectsOfType(typeof(T)).Length > 1) {
                        //    if(Application.isEditor)
                        //        Debug.LogError(string.Concat("[Singleton] Something went really wrong ", " - there should never be more than 1 singleton!", " Reopening the scene might fix it."));
                        //    return _instance;
                        //}
                        
                        //if(Application.isEditor)
                        //    Debug.LogWarning(string.Concat("[Singleton] Using instance already created: ", _instance.gameObject.name));
                    }

                    return _instance;
                }
            }
        }

        #endregion

        private static bool applicationIsQuitting = false;
	    /// <summary>
	    /// When Unity quits, it destroys objects in a random order.
	    /// In principle, a Singleton is only destroyed when application quits.
	    /// If any script calls Instance after it have been destroyed, 
	    ///   it will create a buggy ghost object that will stay on the Editor scene
	    ///   even after stopping playing the Application. Really bad!
	    /// So, this was made to be sure we're not creating that buggy ghost object.
	    /// </summary>
	    public void OnDestroy () {
		    applicationIsQuitting = true;
	    }

    }

}