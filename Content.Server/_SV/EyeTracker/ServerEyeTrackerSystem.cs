using Content.Shared.Popups;
using Content.Shared._SV.EyeTracker;

namespace Content.Server._SV.EyeTracker;

//[Access(typeof(EyeTrackerComponent))]
public sealed class SharedEyeTrackerSystem : EntitySystem
{
    [Dependency] private readonly SharedPopupSystem _popupSystem = default!;
    [Dependency] private readonly IEntityManager _entityManager = default!;

    private void GetEyeRotationEvent(GetEyeRotationEvent ev)
    {
        //Used for clientside event
    }

    public void SetEyeRotation(Angle angle, NetEntity tracker, EntityUid player)
    {

        _entityManager.TryGetEntity(tracker, out var entity);

        if (!_entityManager.TryGetComponent<EyeTrackerComponent>(_entityManager.GetEntity(tracker), out var eye))
            return;
        //_adminLog.Add(LogType.RCD,
        //    LogImpact.Extreme,
        //    $"{ToPrettyString(entity)} is setting {eye.ToString()} to {angle}");
        //_popupSystem.PopupClient($"{ToPrettyString(player)} is setting {entity} to {angle}", player);
        eye.Rotation = angle;
    }
}
