using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Stripe.Android.Model
{
    public sealed partial class PaymentMethodCreateParams
    {
        public sealed partial class Card : global::Java.Lang.Object
        {
            public sealed partial class Builder : global::Java.Lang.Object
			{
                static readonly JniPeerMembers _members = new XAPeerMembers("com/stripe/android/model/PaymentMethodCreateParams$Card$Builder", typeof(Builder));

				public unsafe Builder()
					: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
				{
					const string __id = "()V";

					if (((global::Java.Lang.Object)this).Handle != IntPtr.Zero)
						return;

					try
					{
						var __r = _members.InstanceMethods.StartCreateInstance(__id, ((object)this).GetType(), null);
						SetHandle(__r.Handle, JniHandleOwnership.TransferLocalRef);
						_members.InstanceMethods.FinishCreateInstance(__id, this, null);
					}
					finally
					{
					}
				}

				public unsafe global::Com.Stripe.Android.Model.PaymentMethodCreateParams.Card.Builder SetCvc(string cvc)
				{
					const string __id = "setCvc.(Ljava/lang/String;)Lcom/stripe/android/model/PaymentMethodCreateParams$Card$Builder;";
					IntPtr native_cvc = JNIEnv.NewString(cvc);
					try
					{
						JniArgumentValue* __args = stackalloc JniArgumentValue[1];
						__args[0] = new JniArgumentValue(native_cvc);
						var __rm = _members.InstanceMethods.InvokeNonvirtualObjectMethod(__id, this, __args);
						return global::Java.Lang.Object.GetObject<global::Com.Stripe.Android.Model.PaymentMethodCreateParams.Card.Builder>(__rm.Handle, JniHandleOwnership.TransferLocalRef);
					}
					finally
					{
						JNIEnv.DeleteLocalRef(native_cvc);
					}
				}

				public unsafe global::Com.Stripe.Android.Model.PaymentMethodCreateParams.Card.Builder SetExpiryMonth(global::Java.Lang.Integer expiryMonth)
				{
					const string __id = "setExpiryMonth.(Ljava/lang/Integer;)Lcom/stripe/android/model/PaymentMethodCreateParams$Card$Builder;";
					try
					{
						JniArgumentValue* __args = stackalloc JniArgumentValue[1];
						__args[0] = new JniArgumentValue((expiryMonth == null) ? IntPtr.Zero : ((global::Java.Lang.Object)expiryMonth).Handle);
						var __rm = _members.InstanceMethods.InvokeNonvirtualObjectMethod(__id, this, __args);
						return global::Java.Lang.Object.GetObject<global::Com.Stripe.Android.Model.PaymentMethodCreateParams.Card.Builder>(__rm.Handle, JniHandleOwnership.TransferLocalRef);
					}
					finally
					{
					}
				}

				public unsafe global::Com.Stripe.Android.Model.PaymentMethodCreateParams.Card.Builder SetExpiryYear(global::Java.Lang.Integer expiryYear)
				{
					const string __id = "setExpiryYear.(Ljava/lang/Integer;)Lcom/stripe/android/model/PaymentMethodCreateParams$Card$Builder;";
					try
					{
						JniArgumentValue* __args = stackalloc JniArgumentValue[1];
						__args[0] = new JniArgumentValue((expiryYear == null) ? IntPtr.Zero : ((global::Java.Lang.Object)expiryYear).Handle);
						var __rm = _members.InstanceMethods.InvokeNonvirtualObjectMethod(__id, this, __args);
						return global::Java.Lang.Object.GetObject<global::Com.Stripe.Android.Model.PaymentMethodCreateParams.Card.Builder>(__rm.Handle, JniHandleOwnership.TransferLocalRef);
					}
					finally
					{
					}
				}

				public unsafe global::Com.Stripe.Android.Model.PaymentMethodCreateParams.Card.Builder SetNumber(string number)
				{
					const string __id = "setNumber.(Ljava/lang/String;)Lcom/stripe/android/model/PaymentMethodCreateParams$Card$Builder;";
					IntPtr native_number = JNIEnv.NewString(number);
					try
					{
						JniArgumentValue* __args = stackalloc JniArgumentValue[1];
						__args[0] = new JniArgumentValue(native_number);
						var __rm = _members.InstanceMethods.InvokeNonvirtualObjectMethod(__id, this, __args);
						return global::Java.Lang.Object.GetObject<global::Com.Stripe.Android.Model.PaymentMethodCreateParams.Card.Builder>(__rm.Handle, JniHandleOwnership.TransferLocalRef);
					}
					finally
					{
						JNIEnv.DeleteLocalRef(native_number);
					}
				}

				public unsafe global::Com.Stripe.Android.Model.PaymentMethodCreateParams.Card Build()
				{
					const string __id = "build.()Lcom/stripe/android/model/PaymentMethodCreateParams$Card;";
					try
					{
						var __rm = _members.InstanceMethods.InvokeAbstractObjectMethod(__id, this, null);
						return global::Java.Lang.Object.GetObject<global::Com.Stripe.Android.Model.PaymentMethodCreateParams.Card>(__rm.Handle, JniHandleOwnership.TransferLocalRef);
					}
					finally
					{
					}
				}
			}
        }
    }
}
