using ApprovalTests.Namers;
using ApprovalTests.Reporters;
using ApprovalTests.Reporters.Windows;

[assembly: UseReporter(typeof(WinMergeReporter))]
[assembly: UseApprovalSubdirectory("Snapshots")] 