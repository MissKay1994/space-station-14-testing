using Content.Shared._SV.EyeTracker;
using Robust.Client.Graphics;

namespace Content.Client._SV.EyeTracker;
[Access(typeof(EyeTrackerComponent))]

public sealed class EyeTrackerSystem : EntitySystem
{

    [Dependency] private readonly IEyeManager _eyeManager = default!;

    public override void Initialize()
    {
        SubscribeNetworkEvent<GetEyeRotationEvent>(GetEyeRotationEvent);
        base.Initialize();
    }

    private void GetEyeRotationEvent(GetEyeRotationEvent ev)
    {
        ev.EyeTrackerComponent.Rotation = _eyeManager.CurrentEye.Rotation;
    }
}
