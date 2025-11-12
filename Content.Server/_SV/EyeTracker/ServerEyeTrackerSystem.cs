// SPDX-FileCopyrightText: 2025 Sector-Vestige contributors
// SPDX-FileCopyrightText: 2025 Sector Vestige contributors (modifications)
// SPDX-FileCopyrightText: 2025 OnyxTheBrave <vinjeerik@gmail.com>
//
// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared._SV.EyeTracker;

namespace Content.Server._SV.EyeTracker;

[Access(typeof(EyeTrackerComponent))]
public sealed class ServerEyeTrackerSystem : EntitySystem
{
    [Dependency] private readonly IEntityManager _entityManager = default!;
    public override void Initialize()
    {
        SubscribeAllEvent<GetNetworkedEyeRotationEvent>(SetServerEyeRotation);
        base.Initialize();
    }

    private void SetServerEyeRotation(GetNetworkedEyeRotationEvent args)
    {
        if (!_entityManager.TryGetComponent<EyeTrackerComponent>(_entityManager.GetEntity(args.NetEntity), out var tracker))
            return;

        tracker.Rotation = args.Angle;
        Dirty(_entityManager.GetEntity(args.NetEntity), tracker);
    }
}
