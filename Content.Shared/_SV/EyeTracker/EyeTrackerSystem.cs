namespace Content.Shared._SV.EyeTracker;

[Access(typeof(EyeTrackerComponent))]
public sealed class EyeTrackerSystem : EntitySystem
{
    private void GetEyeRotationEvent(GetEyeRotationEvent ev)
    {
        //Used for clientside event
    }
}
