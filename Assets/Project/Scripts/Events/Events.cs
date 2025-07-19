using System;
using UnityEngine.Events;

[Serializable]
public class BalloonDestroyedEvent : UnityEvent<Ball> { }

[Serializable]
public class BalloonClickedEvent : UnityEvent<Ball> { }

[Serializable]
public class BalloonTouchBorderEvent : UnityEvent<Ball> { }


[Serializable]
public class BalloonBurstedEvent : UnityEvent<Ball> { }

[Serializable]
public class BalloonExplodedEvent : UnityEvent<Ball> { }


[Serializable]
public class AddScoreEvent : UnityEvent<int> { }

[Serializable]
public class AddDamageEvent : UnityEvent<int> { }


[Serializable]
public class ChangeHealthEvent : UnityEvent<int> { }

[Serializable]
public class ChangeScoreEvent : UnityEvent<int> { }

[Serializable]
public class ChangeBestScoreEvent : UnityEvent<int> { }
