using System;
using System.Runtime.InteropServices;
using Foundation;
using ObjCRuntime;

namespace StripeBinding.iOS
{
	[Native]
	public enum STPShippingType : ulong
	{
		Shipping,
		Delivery
	}

	[Native]
	public enum STPShippingStatus : ulong
	{
		Valid,
		Invalid
	}

	[Native]
	public enum STPPaymentStatus : ulong
	{
		Success,
		Error,
		UserCancellation
	}

	[Native]
	public enum STPPinStatus : ulong
	{
		Success,
		ErrorVerificationAlreadyRedeemed,
		ErrorVerificationCodeIncorrect,
		ErrorVerificationExpired,
		ErrorVerificationTooManyAttempts,
		EphemeralKeyError,
		UnknownError
	}

	[Native]
	public enum STPFilePurpose : long
	{
		IdentityDocument,
		DisputeEvidence,
		Unknown
	}

	[Native]
	public enum STPBillingAddressFields : ulong
	{
		None,
		PostalCode,
		Full,
		Name,
		Zip = PostalCode
	}

	[Flags]
	[Native]
	public enum STPPaymentOptionType : ulong
	{
		None = 0x0,
		ApplePay = 1uL << 0,
		Fpx = 1uL << 1,
		All = ApplePay,
		Default = ApplePay
	}

	[Native]
	public enum STPBankAccountHolderType : long
	{
		Individual,
		Company
	}

	[Native]
	public enum STPBankAccountStatus : long
	{
		New,
		Validated,
		Verified,
		VerificationFailed,
		Errored
	}

	[Native]
	public enum STPFPXBankBrand : long
	{
		Maybank2U,
		Cimb,
		PublicBank,
		Rhb,
		HongLeongBank,
		Ambank,
		AffinBank,
		AllianceBank,
		BankIslam,
		BankMuamalat,
		BankRakyat,
		Bsn,
		Hsbc,
		Kfh,
		Maybank2E,
		Ocbc,
		StandardChartered,
		Uob,
		Unknown
	}

	[Native]
	public enum STPBankSelectionMethod : long
	{
		Fpx,
		Unknown
	}

	[Native]
	public enum STPCardBrand : long
	{
		Visa,
		Amex,
		MasterCard,
		Discover,
		Jcb,
		DinersClub,
		UnionPay,
		Unknown
	}

	[Native]
	public enum STPCardFundingType : long
	{
		Debit,
		Credit,
		Prepaid,
		Other
	}

	[Native]
	public enum STPCardValidationState : long
	{
		Valid,
		Invalid,
		Incomplete
	}

	[Native]
	public enum STPConnectAccountBusinessType : long
	{
		Individual,
		Company
	}

	[Native]
	public enum STPIntentActionType : ulong
	{
		Unknown,
		RedirectToURL,
		UseStripeSDK,
		AlipayHandleRedirect
	}

	[Native]
	public enum STPKlarnaLineItemType : ulong
	{
		Sku,
		Tax,
		Shipping
	}

	[Native]
	public enum STPMandateCustomerAcceptanceType : long
	{
		nline,
		ffline
	}

	[Native]
	public enum STPPaymentHandlerActionStatus : long
	{
		Succeeded,
		Canceled,
		Failed
	}

	[Native]
	public enum STPPaymentHandlerErrorCode : long
	{
		UnsupportedAuthenticationErrorCode,
		RequiresPaymentMethodErrorCode,
		IntentStatusErrorCode,
		TimedOutErrorCode,
		Stripe3DS2ErrorCode,
		NotAuthenticatedErrorCode,
		NoConcurrentActionsErrorCode,
		RequiresAuthenticationContextErrorCode,
		PaymentErrorCode,
		InvalidClientSecret
	}

	[Native]
	public enum STPPaymentIntentStatus : long
	{
		Unknown,
		RequiresPaymentMethod,
		RequiresSource = RequiresPaymentMethod,
		RequiresConfirmation,
		RequiresAction,
		RequiresSourceAction = RequiresAction,
		Processing,
		Succeeded,
		RequiresCapture,
		Canceled
	}

	[Native]
	public enum STPPaymentIntentCaptureMethod : long
	{
		Unknown,
		Automatic,
		Manual
	}

	[Native]
	public enum STPPaymentIntentConfirmationMethod : long
	{
		Unknown,
		Manual,
		Automatic
	}

	[Native]
	public enum STPPaymentIntentSetupFutureUsage : long
	{
		Unknown,
		None,
		OnSession,
		OffSession
	}

	[Native]
	public enum STPPaymentIntentActionType : ulong
	{
		Unknown,
		RedirectToURL
	}

	[Native]
	public enum STPPaymentIntentSourceActionType : ulong
	{
		Unknown,
		AuthorizeWithURL
	}

	[Native]
	public enum STPPaymentMethodType : ulong
	{
		Card,
		Alipay,
		iDEAL,
		Fpx,
		CardPresent,
		SEPADebit,
		AUBECSDebit,
		BacsDebit,
		Giropay,
		Przelewy24,
		Eps,
		Bancontact,
		Unknown
	}

	[Native]
	public enum STPPaymentIntentLastPaymentErrorType : ulong
	{
		Unknown,
		APIConnection,
		Api,
		Authentication,
		Card,
		Idempotency,
		InvalidRequest,
		RateLimit
	}

	[Native]
	public enum STPPaymentMethodCardCheckResult : ulong
	{
		Pass,
		Failed,
		Unavailable,
		Unchecked,
		Unknown
	}

	[Native]
	public enum STPPaymentMethodCardWalletType : ulong
	{
		AmexExpressCheckout,
		ApplePay,
		GooglePay,
		Masterpass,
		SamsungPay,
		VisaCheckout,
		Unknown
	}

	[Native]
	public enum STPRedirectContextErrorCode : long
	{
		STPRedirectContextAppRedirectError
	}

	[Native]
	public enum STPRedirectContextState : ulong
	{
		NotStarted,
		InProgress,
		Cancelled,
		Completed
	}

	[Native]
	public enum STPSetupIntentStatus : long
	{
		Unknown,
		RequiresPaymentMethod,
		RequiresConfirmation,
		RequiresAction,
		Processing,
		Succeeded,
		Canceled
	}

	[Native]
	public enum STPSetupIntentUsage : long
	{
		Unknown,
		None,
		OnSession,
		OffSession
	}

	[Native]
	public enum STPSetupIntentLastSetupErrorType : ulong
	{
		Unknown,
		APIConnection,
		Api,
		Authentication,
		Card,
		Idempotency,
		InvalidRequest,
		RateLimit
	}

	[Native]
	public enum STPSourceCard3DSecureStatus : long
	{
		Required,
		Optional,
		NotSupported,
		Recommended,
		Unknown
	}

	[Native]
	public enum STPSourceFlow : long
	{
		None,
		Redirect,
		CodeVerification,
		Receiver,
		Unknown
	}

	[Native]
	public enum STPSourceUsage : long
	{
		Reusable,
		SingleUse,
		Unknown
	}

	[Native]
	public enum STPSourceStatus : long
	{
		Pending,
		Chargeable,
		Consumed,
		Canceled,
		Failed,
		Unknown
	}

	[Native]
	public enum STPSourceType : long
	{
		Bancontact,
		Card,
		Giropay,
		Ideal,
		SEPADebit,
		Sofort,
		ThreeDSecure,
		Alipay,
		P24,
		Eps,
		Multibanco,
		WeChatPay,
		Klarna,
		Unknown
	}

	[Flags]
	[Native]
	public enum STPKlarnaPaymentMethods : ulong
	{
		None = 0x0,
		PayIn4 = 1uL << 0,
		Installments = 1uL << 1
	}

	[Native]
	public enum STPSourceRedirectStatus : long
	{
		Pending,
		Succeeded,
		Failed,
		NotRequired,
		Unknown
	}

	[Native]
	public enum STPSourceVerificationStatus : long
	{
		Pending,
		Succeeded,
		Failed,
		Unknown
	}

	[Native]
	public enum STPThreeDSCustomizationButtonType : long
	{
		Submit = 0,
		Continue = 1,
		Next = 2,
		Cancel = 3,
		Resend = 4
	}

	[Native]
	public enum STPThreeDSButtonTitleStyle : long
	{
		Default,
		Uppercase,
		Lowercase,
		SentenceCapitalized
	}

	[Native]
	public enum STPTokenType : long
	{
		Account = 0,
		BankAccount,
		Card,
		Pii,
		CVCUpdate
	}

	[Native]
	public enum STPErrorCode : long
	{
		ConnectionError = 40,
		InvalidRequestError = 50,
		APIError = 60,
		CardError = 70,
		CancellationError = 80,
		EphemeralKeyDecodingError = 1000
	}

	[Native]
	public enum STDSUICustomizationButtonType : long
	{
		Submit = 0,
		Continue = 1,
		Next = 2,
		Cancel = 3,
		Resend = 4
	}

	[Native]
	public enum STDSButtonTitleStyle : long
	{
		Default,
		Uppercase,
		Lowercase,
		SentenceCapitalized
	}

	[Native]
	public enum STDSWarningSeverity : long
	{
		Low = 0,
		Medium,
		High
	}

	[Native]
	public enum STDSErrorMessageCode : long
	{
		CodeInvalidMessage = 101,
		CodeRequiredDataElementMissing = 201,
		CodeUnrecognizedCriticalMessageExtension = 202,
		ErrorInvalidDataElement = 203,
		ErrorTransactionIDNotRecognized = 301,
		ErrorDataDecryptionFailure = 302,
		ErrorTimeout = 402
	}

	[Native]
	public enum STDSErrorCode : long
	{
		AssertionFailed = 204,
		JSONFieldInvalid = 203,
		JSONFieldMissing = 201,
		UnrecognizedCriticalMessageExtension = 202,
		DecryptionVerification = 302,
		RuntimeParsing = 400,
		RuntimeEncryption = 401,
		ReceivedErrorMessage = 1000,
		UnknownMessageType = 1001,
		Timeout = 1002,
		UnknownError = 2000
	}

	[Native]
	public enum STDSACSStatusType : long
	{
		Unknown = 0,
		Authenticated = 1,
		ChallengeRequired = 2,
		DecoupledAuthentication = 3,
		NotAuthenticated = 4,
		ProofGenerated = 5,
		Error = 6,
		Rejected = 7,
		InformationalOnly = 8
	}
}
