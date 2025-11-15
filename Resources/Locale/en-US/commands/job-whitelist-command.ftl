cmd-jobwhitelist-job-does-not-exist = Job {$job} does not exist.
cmd-jobwhitelist-player-not-found = Player {$player} not found.
cmd-jobwhitelist-hint-player = [player]
cmd-jobwhitelist-hint-job = [job]
cmd-jobwhitelist-group-does-not-exist = Group {$group} does not exist.

cmd-jobwhitelistadd-desc = Lets a player play a whitelisted job.
cmd-jobwhitelistadd-help = Usage: jobwhitelistadd <username> <job>
cmd-jobwhitelistadd-already-whitelisted = {$player} is already whitelisted to play as {$jobId} .({$jobName}).
cmd-jobwhitelistadd-added = Added {$player} to the {$jobId} ({$jobName}) whitelist.

cmd-jobwhitelistget-desc = Gets all the jobs that a player has been whitelisted for.
cmd-jobwhitelistget-help = Usage: jobwhitelistget <username>
cmd-jobwhitelistget-whitelisted-none = Player {$player} is not whitelisted for any jobs.
cmd-jobwhitelistget-whitelisted-for = "Player {$player} is whitelisted for:
{$jobs}"

cmd-jobwhitelistremove-desc = Removes a player's ability to play a whitelisted job.
cmd-jobwhitelistremove-help = Usage: jobwhitelistremove <username> <job>
cmd-jobwhitelistremove-was-not-whitelisted = {$player} was not whitelisted to play as {$jobId} ({$jobName}).
cmd-jobwhitelistremove-removed = Removed {$player} from the whitelist for {$jobId} ({$jobName}).

cmd-jobwhitelistaddgroup-desc = Adds a player to a job whitelist group, granting access to multiple jobs at once.
cmd-jobwhitelistaddgroup-help = Usage: jobwhitelistaddgroup <username> <group>
cmd-jobwhitelistaddgroup-arg-player = [player]
cmd-jobwhitelistaddgroup-arg-group = [group]
cmd-jobwhitelistaddgroup-already-whitelisted = {$player} is already in the {$group} group.
cmd-jobwhitelistaddgroup-added = Added {$player} to the {$group} group.

cmd-jobwhitelistremovegroup-desc = Removes a player from a job whitelist group.
cmd-jobwhitelistremovegroup-help = Usage: jobwhitelistremovegroup <username> <group>
cmd-jobwhitelistremovegroup-arg-player = [player]
cmd-jobwhitelistremovegroup-arg-group = [group]
cmd-jobwhitelistremovegroup-not-whitelisted = {$player} is not in the {$group} group.
cmd-jobwhitelistremovegroup-removed = Removed {$player} from the {$group} group.
