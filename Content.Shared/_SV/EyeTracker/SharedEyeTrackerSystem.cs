namespace Content.Shared._SV.EyeTracker;
using Content.Shared.Popups;


//[Access(typeof(EyeTrackerComponent))]
public sealed class SharedEyeTrackerSystem : EntitySystem
{
    [Dependency] private readonly SharedPopupSystem _popupSystem = default!;
    private void GetEyeRotationEvent(GetEyeRotationEvent ev)
    {
        //Used for clientside event
    }

    public void SetEyeRotation(Angle angle, EyeTrackerComponent component, EntityUid uid)
    {
        //_popupSystem.PopupClient( component.ToString(), uid);
        component.Rotation = angle;
    }
}
