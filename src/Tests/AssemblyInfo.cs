// The tests use global switches to control Npgsql behaviour so they can't run in parallel
[assembly: Xunit.CollectionBehavior(DisableTestParallelization = true)]
