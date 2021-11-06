using System;
using UnityEngine.Events;

[Serializable] public class BalloonDestroyedEvent : UnityEvent<Balloon> { }
[Serializable] public class BalloonClickedEvent : UnityEvent<Balloon> { }
[Serializable] public class BalloonTouchBorderEvent : UnityEvent<Balloon> { }

[Serializable] public class BalloonBurstedEvent : UnityEvent<Balloon> { }
[Serializable] public class BalloonExplodedEvent : UnityEvent<Balloon> { }

[Serializable] public class AddScoreEvent : UnityEvent<int> { }
[Serializable] public class AddDamageEvent : UnityEvent<int> { }

[Serializable] public class ChangeHealthEvent : UnityEvent<int> { }
[Serializable] public class ChangeScoreEvent : UnityEvent<int> { }
[Serializable] public class ChangeBestScoreEvent : UnityEvent<int> { }