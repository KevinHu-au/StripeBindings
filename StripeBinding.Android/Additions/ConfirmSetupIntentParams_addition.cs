using Android.Runtime;
using Java.Interop;

namespace Com.Stripe.Android.Model
{
    public sealed partial class ConfirmSetupIntentParams : global::Java.Lang.Object, global::Com.Stripe.Android.Model.IConfirmStripeIntentParams
    {
		public unsafe global::Com.Stripe.Android.Model.IConfirmStripeIntentParams WithShouldUseStripeSdk(bool shouldUseStripeSdk)
		{
			JniPeerMembers _members = new XAPeerMembers("com/stripe/android/model/ConfirmSetupIntentParams", typeof(ConfirmSetupIntentParams));
			const string __id = "withShouldUseStripeSdk.(Z)Lcom/stripe/android/model/ConfirmSetupIntentParams;";
			try
			{
				JniArgumentValue* __args = stackalloc JniArgumentValue[1];
				__args[0] = new JniArgumentValue(shouldUseStripeSdk);
				var __rm = _members.InstanceMethods.InvokeAbstractObjectMethod(__id, this, __args);
				return global::Java.Lang.Object.GetObject<global::Com.Stripe.Android.Model.ConfirmSetupIntentParams>(__rm.Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
			}
		}

        public string ClientSecret { get; set; }
    }
}
