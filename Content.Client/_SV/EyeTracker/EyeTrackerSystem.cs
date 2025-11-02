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

    public override void Initialize()
    {
        SubscribeNetworkEvent<GetEyeRotationEvent>(GetEyeRotation);
        base.Initialize();
    }

    private void GetEyeRotation(GetEyeRotationEvent ev)
    {
        var entity = _entityManager.GetEntity(ev.NetEntity);
        if (!_entityManager.TryGetComponent<EyeTrackerComponent>(entity, out var eye))
        {
            _popupSystem.PopupClient("FUCK", _entityManager.GetEntity(ev.PlayerEntity));
            return;
        }

        eye.Rotation = _eyeManager.CurrentEye.Rotation;
    }
}
