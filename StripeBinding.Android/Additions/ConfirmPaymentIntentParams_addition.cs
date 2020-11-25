using Android.Runtime;
using Java.Interop;

namespace Com.Stripe.Android.Model
{
    public sealed partial class ConfirmPaymentIntentParams : global::Java.Lang.Object, global::Com.Stripe.Android.Model.IConfirmStripeIntentParams
	{
		public unsafe global::Com.Stripe.Android.Model.IConfirmStripeIntentParams WithShouldUseStripeSdk(bool shouldUseStripeSdk)
		{
			JniPeerMembers _members = new XAPeerMembers("com/stripe/android/model/ConfirmPaymentIntentParams", typeof(ConfirmPaymentIntentParams));
			const string __id = "withShouldUseStripeSdk.(Z)Lcom/stripe/android/model/ConfirmPaymentIntentParams;";
			try
			{
				JniArgumentValue* __args = stackalloc JniArgumentValue[1];
				__args[0] = new JniArgumentValue(shouldUseStripeSdk);
				var __rm = _members.InstanceMethods.InvokeAbstractObjectMethod(__id, this, __args);
				return global::Java.Lang.Object.GetObject<global::Com.Stripe.Android.Model.ConfirmPaymentIntentParams>(__rm.Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
			}
		}
	}

	public partial interface IConfirmStripeIntentParams
    {
	}
}
