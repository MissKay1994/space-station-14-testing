namespace Content.Shared._SV.EyeTracker;

[Access(typeof(EyeTrackerComponent))]
public sealed class EyeTrackerSystem : EntitySystem
{
    private void GetEyeRotationEvent(NetEntity netEntity, Angle eyeAngle, EyeTrackerComponent component)
    {
        //Used for clientside event
    }
}
