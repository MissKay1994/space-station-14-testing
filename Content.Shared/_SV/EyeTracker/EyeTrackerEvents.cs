using Robust.Shared.Serialization;

namespace Content.Shared._SV.EyeTracker;

/// <summary>
/// Get and network the current eye rotation
/// </summary>
[Serializable, NetSerializable]
public sealed class GetEyeRotationEvent : EntityEventArgs
{
    public EyeTrackerComponent EyeTrackerComponent { get; set; }

    public GetEyeRotationEvent(EyeTrackerComponent component)
    {
        EyeTrackerComponent = component;
    }
}
