using Content.Shared._SV.EyeTracker;
using Robust.Client.Graphics;
using Robust.Shared.Player;

namespace Content.Client._SV.EyeTracker;
[Access(typeof(EyeTrackerComponent))]

public sealed class EyeTrackerSystem : EntitySystem
{

    [Dependency] private readonly IEyeManager _eyeManager = default!;
    [Dependency] private readonly IEntityManager _entityManager = default!;
    [Dependency] private readonly ISharedPlayerManager _playerManager = default!;
    [Dependency] private readonly IEntityNetworkManager _entityNetworkManager = default!;

    public override void Initialize()
    {
        SubscribeAllEvent<GetEyeRotationEvent>(GetEyeRotation);
        base.Initialize();
    }

    private void GetEyeRotation(GetEyeRotationEvent args)
    {
        if (_playerManager.LocalSession == null)
        {
            return;
        }

        if (_playerManager.LocalSession.AttachedEntity != _entityManager.GetEntity(args.PlayerEntity))
        {
            return;
        }

        var entity = _entityManager.GetEntity(args.NetEntity);

        if (!_entityManager.TryGetComponent<EyeTrackerComponent>(entity, out var eye))
        {
            return;
        }

        //Set the client side for fun
        eye.Rotation = _eyeManager.CurrentEye.Rotation;
        _entityNetworkManager.SendSystemNetworkMessage(new GetNetworkedEyeRotationEvent(args.NetEntity, _eyeManager.CurrentEye.Rotation));
    }
}
