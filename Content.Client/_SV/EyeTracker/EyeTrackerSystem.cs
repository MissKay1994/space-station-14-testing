using Content.Shared._SV.EyeTracker;
using Content.Shared.Interaction;
using Content.Shared.Popups;
using Content.Shared.RCD.Components;
using Robust.Client.Console;
using Robust.Client.Graphics;

namespace Content.Client._SV.EyeTracker;
[Access(typeof(EyeTrackerComponent))]

public sealed class EyeTrackerSystem : EntitySystem
{

    [Dependency] private readonly IEyeManager _eyeManager = default!;
    [Dependency] private readonly IEntityManager _entityManager = default!;
    [Dependency] private readonly SharedPopupSystem _popupSystem = default!;
    [Dependency] private readonly SharedEyeTrackerSystem _eyeTrackerSystem = default!;

    public override void Initialize()
    {
        SubscribeNetworkEvent<GetEyeRotationEvent>(GetEyeRotation);
        base.Initialize();
    }

    private void GetEyeRotation(GetEyeRotationEvent ev)
    {
        var entity = _entityManager.GetEntity(ev.NetEntity);
        _popupSystem.PopupClient(entity.ToString(), _entityManager.GetEntity(ev.NetEntity));
        if (!_entityManager.TryGetComponent<EyeTrackerComponent>(entity, out var eye))
        {
            return;
        }
        _eyeTrackerSystem.SetEyeRotation(_eyeManager.CurrentEye.Rotation, eye, _entityManager.GetEntity(ev.PlayerEntity));
    }
}
