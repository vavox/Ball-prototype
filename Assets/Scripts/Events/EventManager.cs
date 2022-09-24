using System.Collections.Generic;
using UnityEngine.Events;

public static class EventManager
{
    #region Fields
    static List<PlayerController> addForceInvokers = new List<PlayerController>();
    static List<UnityAction> addForceListeners = new List<UnityAction>();

    static List<PlayerController> changeScaleInvokers = new List<PlayerController>();
    static List<UnityAction<float>> changeScaleListeners = new List<UnityAction<float>>();

    static List<ShootingBall> setAreaInvokers = new List<ShootingBall>();
    static List<UnityAction<float>> setAreaListeners = new List<UnityAction<float>>();

    static List<PlayerController> changePathSizeInvokers = new List<PlayerController>();
    static List<UnityAction<float>> changePathSizeListeners = new List<UnityAction<float>>();

    static List<PlayerController> gameWonInvokers = new List<PlayerController>();
    static List<UnityAction<bool>> gameWonListeners = new List<UnityAction<bool>>();

    static List<PlayerController> gameLostInvokers = new List<PlayerController>();
    static List<UnityAction<bool>> gameLostListeners = new List<UnityAction<bool>>();

    static List<GameplayManager> canShootInvokers = new List<GameplayManager>();
    static List<UnityAction<bool>> canShootListeners = new List<UnityAction<bool>>();

    static List<PathQuad> canMoveToDoorInvokers = new List<PathQuad>();
    static List<UnityAction<bool>> canMoveToDoorListeners = new List<UnityAction<bool>>();
    #endregion

    #region AddForceEvent
    public static void AddAddForceInvoker(PlayerController invoker)
    {
        addForceInvokers.Add(invoker);
        foreach(UnityAction listener in addForceListeners)
        {
            invoker.AddAddForceListener(listener);
        }    
    }

    public static void AddAddForceListener(UnityAction listener)
    {
        addForceListeners.Add(listener);
        foreach(PlayerController invoker in addForceInvokers)
        {
            invoker.AddAddForceListener(listener);
        }
    }

    public static void RemoveAddForceInvoker(PlayerController invoker)
    {
        // remove invoker from list
        addForceInvokers.Remove(invoker);
    }
    #endregion

    #region ChangeScaleEvent
    public static void AddChangeScaleInvoker(PlayerController invoker)
    {
        changeScaleInvokers.Add(invoker);
        foreach(UnityAction<float> listener in changeScaleListeners)
        {
            invoker.AddChangeScaleListener(listener);
        }    
    }

    public static void AddChangeScaleListener(UnityAction<float> listener)
    {
        changeScaleListeners.Add(listener);
        foreach(PlayerController invoker in changeScaleInvokers)
        {
            invoker.AddChangeScaleListener(listener);
        }
    }

    public static void RemoveChangeScaleInvoker(PlayerController invoker)
    {
        // remove invoker from list
        changeScaleInvokers.Remove(invoker);
    }
    #endregion

    #region SetAreaEvent
    public static void AddSetAreaInvoker(ShootingBall invoker)
    {
        setAreaInvokers.Add(invoker);
        foreach(UnityAction<float> listener in setAreaListeners)
        {
            invoker.AddSetAreaListener(listener);
        }    
    }

    public static void AddSetAreaListener(UnityAction<float> listener)
    {
        setAreaListeners.Add(listener);
        foreach(ShootingBall invoker in setAreaInvokers)
        {
            invoker.AddSetAreaListener(listener);
        }
    }

    public static void RemoveSetAreaInvoker(ShootingBall invoker)
    {
        // remove invoker from list
        setAreaInvokers.Remove(invoker);
    }
    #endregion

    #region ChangePathSizeEvent
    public static void AddChangePathSizeInvoker(PlayerController invoker)
    {
        changePathSizeInvokers.Add(invoker);
        foreach(UnityAction<float> listener in changePathSizeListeners)
        {
            invoker.AddChangePathSizeListener(listener);
        }    
    }

    public static void AddChangePathSizeListener(UnityAction<float> listener)
    {
        changePathSizeListeners.Add(listener);
        foreach(PlayerController invoker in changePathSizeInvokers)
        {
            invoker.AddChangePathSizeListener(listener);
        }
    }

    public static void RemoveChangePathSizeInvoker(PlayerController invoker)
    {
        // remove invoker from list
        changePathSizeInvokers.Remove(invoker);
    }
    #endregion

    #region CanShootEvent
    public static void AddCanShootInvoker(GameplayManager invoker)
    {
        canShootInvokers.Add(invoker);
        foreach(UnityAction<bool> listener in canShootListeners)
        {
            invoker.AddCanShootListener(listener);
        }    
    }

    public static void AddCanShootListener(UnityAction<bool> listener)
    {
        canShootListeners.Add(listener);
        foreach(GameplayManager invoker in canShootInvokers)
        {
            invoker.AddCanShootListener(listener);
        }
    }

    public static void RemoveCanShootInvoker(GameplayManager invoker)
    {
        // remove invoker from list
        canShootInvokers.Remove(invoker);
    }
    #endregion

    #region CanMoveToDoorEvent
    public static void AddCanMoveToDoorInvoker(PathQuad invoker)
    {
        canMoveToDoorInvokers.Add(invoker);
        foreach(UnityAction<bool> listener in canMoveToDoorListeners)
        {
            invoker.AddCanMoveToDoorListener(listener);
        }    
    }

    public static void AddCanMoveToDoorListener(UnityAction<bool> listener)
    {
        canMoveToDoorListeners.Add(listener);
        foreach(PathQuad invoker in canMoveToDoorInvokers)
        {
            invoker.AddCanMoveToDoorListener(listener);
        }
    }

    public static void RemoveCanMoveToDoorInvoker(PathQuad invoker)
    {
        // remove invoker from list
        canMoveToDoorInvokers.Remove(invoker);
    }
    #endregion

    #region GameWonEvent
    public static void AddGameWonInvoker(PlayerController invoker)
    {
        gameWonInvokers.Add(invoker);
        foreach(UnityAction<bool> listener in gameWonListeners)
        {
            invoker.AddGameWonListener(listener);
        }    
    }

    public static void AddGameWonListener(UnityAction<bool> listener)
    {
        gameWonListeners.Add(listener);
        foreach(PlayerController invoker in gameWonInvokers)
        {
            invoker.AddGameWonListener(listener);
        }
    }

    public static void RemoveGameWonInvoker(PlayerController invoker)
    {
        // remove invoker from list
        gameWonInvokers.Remove(invoker);
    }
    #endregion

    #region GameLostEvent
        public static void AddGameLostInvoker(PlayerController invoker)
    {
        gameLostInvokers.Add(invoker);
        foreach(UnityAction<bool> listener in gameLostListeners)
        {
            invoker.AddGameLostListener(listener);
        }    
    }

    public static void AddGameLostListener(UnityAction<bool> listener)
    {
        gameLostListeners.Add(listener);
        foreach(PlayerController invoker in gameLostInvokers)
        {
            invoker.AddGameLostListener(listener);
        }
    }

    public static void RemoveGameLostInvoker(PlayerController invoker)
    {
        // remove invoker from list
        gameLostInvokers.Remove(invoker);
    }
    #endregion
}
