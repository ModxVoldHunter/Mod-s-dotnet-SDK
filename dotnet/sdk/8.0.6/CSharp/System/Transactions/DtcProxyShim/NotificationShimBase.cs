namespace System.Transactions.DtcProxyShim;

internal class NotificationShimBase
{
	public object EnlistmentIdentifier;

	public ShimNotificationType NotificationType;

	public bool AbortingHint;

	public bool IsSinglePhase;

	public byte[] PrepareInfo;

	protected DtcProxyShimFactory ShimFactory;

	internal NotificationShimBase(DtcProxyShimFactory shimFactory, object enlistmentIdentifier)
	{
		ShimFactory = shimFactory;
		EnlistmentIdentifier = enlistmentIdentifier;
		NotificationType = ShimNotificationType.None;
		AbortingHint = false;
		IsSinglePhase = false;
	}
}
