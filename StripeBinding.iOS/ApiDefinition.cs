using System;
using Contacts;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using PassKit;
using SafariServices;
using UIKit;

namespace StripeBinding.iOS
{
	// typedef void (^STPVoidBlock)();
	delegate void STPVoidBlock();

	// typedef void (^STPErrorBlock)(NSError * _Nullable);
	delegate void STPErrorBlock([NullAllowed] NSError arg0);

	// typedef void (^STPBooleanSuccessBlock)(BOOL, NSError * _Nullable);
	delegate void STPBooleanSuccessBlock(bool arg0, [NullAllowed] NSError arg1);

	// typedef void (^STPJSONResponseCompletionBlock)(NSDictionary * _Nullable, NSError * _Nullable);
	delegate void STPJSONResponseCompletionBlock([NullAllowed] NSDictionary arg0, [NullAllowed] NSError arg1);

	// typedef void (^STPTokenCompletionBlock)(STPToken * _Nullable, NSError * _Nullable);
	delegate void STPTokenCompletionBlock([NullAllowed] STPToken arg0, [NullAllowed] NSError arg1);

	// typedef void (^STPSourceCompletionBlock)(STPSource * _Nullable, NSError * _Nullable);
	delegate void STPSourceCompletionBlock([NullAllowed] STPSource arg0, [NullAllowed] NSError arg1);

	// typedef void (^STPSourceProtocolCompletionBlock)(id<STPSourceProtocol> _Nullable, NSError * _Nullable);
	delegate void STPSourceProtocolCompletionBlock([NullAllowed] STPSourceProtocol arg0, [NullAllowed] NSError arg1);

	// typedef void (^STPPaymentIntentCompletionBlock)(STPPaymentIntent * _Nullable, NSError * _Nullable);
	delegate void STPPaymentIntentCompletionBlock([NullAllowed] STPPaymentIntent arg0, [NullAllowed] NSError arg1);

	// typedef void (^STPSetupIntentCompletionBlock)(STPSetupIntent * _Nullable, NSError * _Nullable);
	delegate void STPSetupIntentCompletionBlock([NullAllowed] STPSetupIntent arg0, [NullAllowed] NSError arg1);

	// typedef void (^STPPaymentMethodCompletionBlock)(STPPaymentMethod * _Nullable, NSError * _Nullable);
	delegate void STPPaymentMethodCompletionBlock([NullAllowed] STPPaymentMethod arg0, [NullAllowed] NSError arg1);

	// typedef void (^STPPaymentMethodsCompletionBlock)(NSArray<STPPaymentMethod *> * _Nullable, NSError * _Nullable);
	delegate void STPPaymentMethodsCompletionBlock([NullAllowed] STPPaymentMethod[] arg0, [NullAllowed] NSError arg1);

	// typedef void (^STPShippingMethodsCompletionBlock)(STPShippingStatus, NSError * _Nullable, NSArray<PKShippingMethod *> * _Nullable, PKShippingMethod * _Nullable);
	delegate void STPShippingMethodsCompletionBlock(STPShippingStatus arg0, [NullAllowed] NSError arg1, [NullAllowed] PKShippingMethod[] arg2, [NullAllowed] PKShippingMethod arg3);

	// typedef void (^STPFileCompletionBlock)(STPFile * _Nullable, NSError * _Nullable);
	delegate void STPFileCompletionBlock([NullAllowed] STPFile arg0, [NullAllowed] NSError arg1);

	// typedef void (^STPCustomerCompletionBlock)(STPCustomer * _Nullable, NSError * _Nullable);
	delegate void STPCustomerCompletionBlock([NullAllowed] STPCustomer arg0, [NullAllowed] NSError arg1);

	// typedef void (^STPPaymentStatusBlock)(STPPaymentStatus, NSError * _Nullable);
	delegate void STPPaymentStatusBlock(STPPaymentStatus arg0, [NullAllowed] NSError arg1);

	// typedef void (^STPIntentClientSecretCompletionBlock)(NSString * _Nullable, NSError * _Nullable);
	delegate void STPIntentClientSecretCompletionBlock([NullAllowed] string arg0, [NullAllowed] NSError arg1);

	// @protocol STPAPIResponseDecodable <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol]
	[BaseType(typeof(NSObject))]
	interface STPAPIResponseDecodable
	{
		// @required +(instancetype _Nullable)decodedObjectFromAPIResponse:(NSDictionary * _Nullable)response;
		[Abstract]
		[Export("decodedObjectFromAPIResponse:")]
		[return: NullAllowed]
		STPAPIResponseDecodable DecodedObjectFromAPIResponse([NullAllowed] NSDictionary response);

		// @required @property (readonly, copy, nonatomic) NSDictionary * _Nonnull allResponseFields;
		[Abstract]
		[Export("allResponseFields", ArgumentSemantic.Copy)]
		NSDictionary AllResponseFields { get; }
	}

	// @interface STPFile : NSObject <STPAPIResponseDecodable>
	[BaseType(typeof(NSObject))]
	interface STPFile
	{
		// @property (readonly, nonatomic) NSString * _Nonnull fileId;
		[Export("fileId")]
		string FileId { get; }

		// @property (readonly, nonatomic) NSDate * _Nonnull created;
		[Export("created")]
		NSDate Created { get; }

		// @property (readonly, nonatomic) STPFilePurpose purpose;
		[Export("purpose")]
		STPFilePurpose Purpose { get; }

		// @property (readonly, nonatomic) NSNumber * _Nonnull size;
		[Export("size")]
		NSNumber Size { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull type;
		[Export("type")]
		string Type { get; }

		// +(NSString * _Nullable)stringFromPurpose:(STPFilePurpose)purpose;
		[Static]
		[Export("stringFromPurpose:")]
		[return: NullAllowed]
		string StringFromPurpose(STPFilePurpose purpose);
	}

	// @interface Stripe : NSObject
	[BaseType(typeof(NSObject))]
	interface Stripe
	{
		// +(NSString * _Nullable)defaultPublishableKey;
		// +(void)setDefaultPublishableKey:(NSString * _Nonnull)publishableKey;
		[Static]
		[NullAllowed, Export("defaultPublishableKey")]
		string DefaultPublishableKey { get; set; }

		// +(BOOL)advancedFraudSignalsEnabled;
		// +(void)setAdvancedFraudSignalsEnabled:(BOOL)enabled;
		[Static]
		[Export("advancedFraudSignalsEnabled")]
		bool AdvancedFraudSignalsEnabled { get; set; }
	}

	// @interface STPAPIClient : NSObject
	[BaseType(typeof(NSObject))]
	interface STPAPIClient
	{
		// +(instancetype _Nonnull)sharedClient;
		[Static]
		[Export("sharedClient")]
		STPAPIClient SharedClient();

		// -(instancetype _Nonnull)initWithPublishableKey:(NSString * _Nonnull)publishableKey;
		[Export("initWithPublishableKey:")]
		IntPtr Constructor(string publishableKey);

		// @property (copy, nonatomic) NSString * _Nullable publishableKey;
		[NullAllowed, Export("publishableKey")]
		string PublishableKey { get; set; }

		// @property (copy, nonatomic) STPPaymentConfiguration * _Nonnull configuration;
		[Export("configuration", ArgumentSemantic.Copy)]
		STPPaymentConfiguration Configuration { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable stripeAccount;
		[NullAllowed, Export("stripeAccount")]
		string StripeAccount { get; set; }

		// @property (nonatomic) STPAppInfo * _Nullable appInfo;
		[NullAllowed, Export("appInfo", ArgumentSemantic.Assign)]
		STPAppInfo AppInfo { get; set; }
	}

	// @interface BankAccounts (STPAPIClient)
	[Category]
	[BaseType(typeof(STPAPIClient))]
	interface STPAPIClient_BankAccounts
	{
		// -(void)createTokenWithBankAccount:(STPBankAccountParams * _Nonnull)bankAccount completion:(STPTokenCompletionBlock _Nullable)completion;
		[Export("createTokenWithBankAccount:completion:")]
		void CreateTokenWithBankAccount(STPBankAccountParams bankAccount, [NullAllowed] STPTokenCompletionBlock completion);
	}

	// @interface PII (STPAPIClient)
	[Category]
	[BaseType(typeof(STPAPIClient))]
	interface STPAPIClient_PII
	{
		// -(void)createTokenWithPersonalIDNumber:(NSString * _Nonnull)pii completion:(STPTokenCompletionBlock _Nullable)completion;
		[Export("createTokenWithPersonalIDNumber:completion:")]
		void CreateTokenWithPersonalIDNumber(string pii, [NullAllowed] STPTokenCompletionBlock completion);

		// -(void)createTokenWithSSNLast4:(NSString * _Nonnull)ssnLast4 completion:(STPTokenCompletionBlock _Nonnull)completion;
		[Export("createTokenWithSSNLast4:completion:")]
		void CreateTokenWithSSNLast4(string ssnLast4, STPTokenCompletionBlock completion);
	}

	// @interface ConnectAccounts (STPAPIClient)
	[Category]
	[BaseType(typeof(STPAPIClient))]
	interface STPAPIClient_ConnectAccounts
	{
		// -(void)createTokenWithConnectAccount:(STPConnectAccountParams * _Nonnull)account completion:(STPTokenCompletionBlock _Nullable)completion;
		[Export("createTokenWithConnectAccount:completion:")]
		void CreateTokenWithConnectAccount(STPConnectAccountParams account, [NullAllowed] STPTokenCompletionBlock completion);
	}

	// @interface Upload (STPAPIClient)
	[Category]
	[BaseType(typeof(STPAPIClient))]
	interface STPAPIClient_Upload
	{
		// -(void)uploadImage:(UIImage * _Nonnull)image purpose:(STPFilePurpose)purpose completion:(STPFileCompletionBlock _Nullable)completion;
		[Export("uploadImage:purpose:completion:")]
		void UploadImage(UIImage image, STPFilePurpose purpose, [NullAllowed] STPFileCompletionBlock completion);
	}

	// @interface CreditCards (STPAPIClient)
	[Category]
	[BaseType(typeof(STPAPIClient))]
	interface STPAPIClient_CreditCards
	{
		// -(void)createTokenWithCard:(STPCardParams * _Nonnull)card completion:(STPTokenCompletionBlock _Nullable)completion;
		[Export("createTokenWithCard:completion:")]
		void CreateTokenWithCard(STPCardParams card, [NullAllowed] STPTokenCompletionBlock completion);

		// -(void)createTokenForCVCUpdate:(NSString * _Nonnull)cvc completion:(STPTokenCompletionBlock _Nullable)completion;
		[Export("createTokenForCVCUpdate:completion:")]
		void CreateTokenForCVCUpdate(string cvc, [NullAllowed] STPTokenCompletionBlock completion);
	}

	// @interface ApplePay (Stripe)
	[Category]
	[BaseType(typeof(Stripe))]
	interface Stripe_ApplePay
	{
		// +(BOOL)canSubmitPaymentRequest:(PKPaymentRequest * _Nonnull)paymentRequest;
		[Static]
		[Export("canSubmitPaymentRequest:")]
		bool CanSubmitPaymentRequest(PKPaymentRequest paymentRequest);

		// +(BOOL)deviceSupportsApplePay;
		[Static]
		[Export("deviceSupportsApplePay")]
		bool DeviceSupportsApplePay { get; }

		// +(PKPaymentRequest * _Nonnull)paymentRequestWithMerchantIdentifier:(NSString * _Nonnull)merchantIdentifier __attribute__((deprecated("")));
		[Static]
		[Export("paymentRequestWithMerchantIdentifier:")]
		PKPaymentRequest PaymentRequestWithMerchantIdentifier(string merchantIdentifier);

		// +(PKPaymentRequest * _Nonnull)paymentRequestWithMerchantIdentifier:(NSString * _Nonnull)merchantIdentifier country:(NSString * _Nonnull)countryCode currency:(NSString * _Nonnull)currencyCode;
		[Static]
		[Export("paymentRequestWithMerchantIdentifier:country:currency:")]
		PKPaymentRequest PaymentRequestWithMerchantIdentifier(string merchantIdentifier, string countryCode, string currencyCode);

		// @property (getter = isJCBPaymentNetworkSupported, nonatomic, class) BOOL JCBPaymentNetworkSupported __attribute__((deprecated("Set additionalApplePayNetworks = @[PKPaymentNetworkJCB] instead")));
		[Static]
		[Export("JCBPaymentNetworkSupported")]
		bool JCBPaymentNetworkSupported { [Bind("isJCBPaymentNetworkSupported")] get; set; }

		// @property (copy, nonatomic, class) NSArray<PKPaymentNetwork> * _Nonnull additionalEnabledApplePayNetworks;
		[Static]
		[Export("additionalEnabledApplePayNetworks", ArgumentSemantic.Copy)]
		string[] AdditionalEnabledApplePayNetworks { get; set; }
	}

	// @interface Sources (STPAPIClient)
	[Category]
	[BaseType(typeof(STPAPIClient))]
	interface STPAPIClient_Sources
	{
		// -(void)createSourceWithParams:(STPSourceParams * _Nonnull)params completion:(STPSourceCompletionBlock _Nonnull)completion;
		[Export("createSourceWithParams:completion:")]
		void CreateSourceWithParams(STPSourceParams @params, STPSourceCompletionBlock completion);

		// -(void)retrieveSourceWithId:(NSString * _Nonnull)identifier clientSecret:(NSString * _Nonnull)secret completion:(STPSourceCompletionBlock _Nonnull)completion;
		[Export("retrieveSourceWithId:clientSecret:completion:")]
		void RetrieveSourceWithId(string identifier, string secret, STPSourceCompletionBlock completion);

		// -(void)startPollingSourceWithId:(NSString * _Nonnull)identifier clientSecret:(NSString * _Nonnull)secret timeout:(NSTimeInterval)timeout completion:(STPSourceCompletionBlock _Nonnull)completion __attribute__((availability(macos_app_extension, unavailable))) __attribute__((availability(ios_app_extension, unavailable))) __attribute__((deprecated("You should poll your own backend to update based on source status change webhook events it may receive.")));
		[Export("startPollingSourceWithId:clientSecret:timeout:completion:")]
		void StartPollingSourceWithId(string identifier, string secret, double timeout, STPSourceCompletionBlock completion);

		// -(void)stopPollingSourceWithId:(NSString * _Nonnull)identifier __attribute__((availability(macos_app_extension, unavailable))) __attribute__((availability(ios_app_extension, unavailable))) __attribute__((deprecated("")));
		[Export("stopPollingSourceWithId:")]
		void StopPollingSourceWithId(string identifier);
	}

	// @interface PaymentIntents (STPAPIClient)
	[Category]
	[BaseType(typeof(STPAPIClient))]
	interface STPAPIClient_PaymentIntents
	{
		// -(void)retrievePaymentIntentWithClientSecret:(NSString * _Nonnull)secret completion:(STPPaymentIntentCompletionBlock _Nonnull)completion;
		[Export("retrievePaymentIntentWithClientSecret:completion:")]
		void RetrievePaymentIntentWithClientSecret(string secret, STPPaymentIntentCompletionBlock completion);

		// -(void)confirmPaymentIntentWithParams:(STPPaymentIntentParams * _Nonnull)paymentIntentParams completion:(STPPaymentIntentCompletionBlock _Nonnull)completion;
		[Export("confirmPaymentIntentWithParams:completion:")]
		void ConfirmPaymentIntentWithParams(STPPaymentIntentParams paymentIntentParams, STPPaymentIntentCompletionBlock completion);
	}

	// @interface SetupIntents (STPAPIClient)
	[Category]
	[BaseType(typeof(STPAPIClient))]
	interface STPAPIClient_SetupIntents
	{
		// -(void)retrieveSetupIntentWithClientSecret:(NSString * _Nonnull)secret completion:(STPSetupIntentCompletionBlock _Nonnull)completion;
		[Export("retrieveSetupIntentWithClientSecret:completion:")]
		void RetrieveSetupIntentWithClientSecret(string secret, STPSetupIntentCompletionBlock completion);

		// -(void)confirmSetupIntentWithParams:(STPSetupIntentConfirmParams * _Nonnull)setupIntentParams completion:(STPSetupIntentCompletionBlock _Nonnull)completion;
		[Export("confirmSetupIntentWithParams:completion:")]
		void ConfirmSetupIntentWithParams(STPSetupIntentConfirmParams setupIntentParams, STPSetupIntentCompletionBlock completion);
	}

	// @interface PaymentMethods (STPAPIClient)
	[Category]
	[BaseType(typeof(STPAPIClient))]
	interface STPAPIClient_PaymentMethods
	{
		// -(void)createPaymentMethodWithParams:(STPPaymentMethodParams * _Nonnull)paymentMethodParams completion:(STPPaymentMethodCompletionBlock _Nonnull)completion;
		[Export("createPaymentMethodWithParams:completion:")]
		void CreatePaymentMethodWithParams(STPPaymentMethodParams paymentMethodParams, STPPaymentMethodCompletionBlock completion);
	}

	// @interface STPURLCallbackHandlerAdditions (Stripe)
	[Category]
	[BaseType(typeof(Stripe))]
	interface Stripe_STPURLCallbackHandlerAdditions
	{
		// +(BOOL)handleStripeURLCallbackWithURL:(NSURL * _Nonnull)url;
		[Static]
		[Export("handleStripeURLCallbackWithURL:")]
		bool HandleStripeURLCallbackWithURL(NSUrl url);
	}

	// @protocol STPFormEncodable <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol]
	[BaseType(typeof(NSObject))]
	interface STPFormEncodable
	{
		// @required +(NSString * _Nullable)rootObjectName;
		[Static, Abstract]
		[NullAllowed, Export("rootObjectName")]
		string RootObjectName { get; }

		// @required +(NSDictionary * _Nonnull)propertyNamesToFormFieldNamesMapping;
		[Static, Abstract]
		[Export("propertyNamesToFormFieldNamesMapping")]
		NSDictionary PropertyNamesToFormFieldNamesMapping { get; }

		// @required @property (readwrite, copy, nonatomic) NSDictionary * _Nonnull additionalAPIParameters;
		[Abstract]
		[Export("additionalAPIParameters", ArgumentSemantic.Copy)]
		NSDictionary AdditionalAPIParameters { get; set; }
	}


	// @interface STPAddress : NSObject <STPAPIResponseDecodable, STPFormEncodable, NSCopying>
	[BaseType(typeof(NSObject))]
	interface STPAddress : INSCopying
	{
		// @property (copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export("name")]
		string Name { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable line1;
		[NullAllowed, Export("line1")]
		string Line1 { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable line2;
		[NullAllowed, Export("line2")]
		string Line2 { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable city;
		[NullAllowed, Export("city")]
		string City { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable state;
		[NullAllowed, Export("state")]
		string State { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable postalCode;
		[NullAllowed, Export("postalCode")]
		string PostalCode { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable country;
		[NullAllowed, Export("country")]
		string Country { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable phone;
		[NullAllowed, Export("phone")]
		string Phone { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable email;
		[NullAllowed, Export("email")]
		string Email { get; set; }

		// +(NSDictionary * _Nullable)shippingInfoForChargeWithAddress:(STPAddress * _Nullable)address shippingMethod:(PKShippingMethod * _Nullable)method;
		[Static]
		[Export("shippingInfoForChargeWithAddress:shippingMethod:")]
		[return: NullAllowed]
		NSDictionary ShippingInfoForChargeWithAddress([NullAllowed] STPAddress address, [NullAllowed] PKShippingMethod method);

		// -(instancetype _Nonnull)initWithPaymentMethodBillingDetails:(STPPaymentMethodBillingDetails * _Nonnull)billingDetails;
		[Export("initWithPaymentMethodBillingDetails:")]
		IntPtr Constructor(STPPaymentMethodBillingDetails billingDetails);

		// -(instancetype _Nonnull)initWithPKContact:(PKContact * _Nonnull)contact;
		[Export("initWithPKContact:")]
		IntPtr Constructor(PKContact contact);

		// -(PKContact * _Nonnull)PKContactValue;
		[Export("PKContactValue")]
		PKContact PKContactValue { get; }

		// -(instancetype _Nonnull)initWithCNContact:(CNContact * _Nonnull)contact;
		[Export("initWithCNContact:")]
		IntPtr Constructor(CNContact contact);

		// -(BOOL)containsRequiredFields:(STPBillingAddressFields)requiredFields;
		[Export("containsRequiredFields:")]
		bool ContainsRequiredFields(STPBillingAddressFields requiredFields);

		// -(BOOL)containsContentForBillingAddressFields:(STPBillingAddressFields)desiredFields;
		[Export("containsContentForBillingAddressFields:")]
		bool ContainsContentForBillingAddressFields(STPBillingAddressFields desiredFields);

		// -(BOOL)containsRequiredShippingAddressFields:(NSSet<STPContactField> * _Nullable)requiredFields;
		[Export("containsRequiredShippingAddressFields:")]
		bool ContainsRequiredShippingAddressFields([NullAllowed] NSSet<NSString> requiredFields);

		// -(BOOL)containsContentForShippingAddressFields:(NSSet<STPContactField> * _Nullable)desiredFields;
		[Export("containsContentForShippingAddressFields:")]
		bool ContainsContentForShippingAddressFields([NullAllowed] NSSet<NSString> desiredFields);

		// +(PKAddressField)applePayAddressFieldsFromBillingAddressFields:(STPBillingAddressFields)billingAddressFields;
		[Static]
		[Export("applePayAddressFieldsFromBillingAddressFields:")]
		PKAddressField ApplePayAddressFieldsFromBillingAddressFields(STPBillingAddressFields billingAddressFields);

		// +(PKAddressField)pkAddressFieldsFromStripeContactFields:(NSSet<STPContactField> * _Nullable)contactFields;
		[Static]
		[Export("pkAddressFieldsFromStripeContactFields:")]
		PKAddressField PkAddressFieldsFromStripeContactFields([NullAllowed] NSSet<NSString> contactFields);

		// +(NSSet<PKContactField> * _Nonnull)applePayContactFieldsFromBillingAddressFields:(STPBillingAddressFields)billingAddressFields __attribute__((availability(ios, introduced=11.0)));
		[iOS(11, 0)]
		[Static]
		[Export("applePayContactFieldsFromBillingAddressFields:")]
		NSSet<NSString> ApplePayContactFieldsFromBillingAddressFields(STPBillingAddressFields billingAddressFields);

		// +(NSSet<PKContactField> * _Nullable)pkContactFieldsFromStripeContactFields:(NSSet<STPContactField> * _Nullable)contactFields __attribute__((availability(ios, introduced=11.0)));
		[iOS(11, 0)]
		[Static]
		[Export("pkContactFieldsFromStripeContactFields:")]
		[return: NullAllowed]
		NSSet<NSString> PkContactFieldsFromStripeContactFields([NullAllowed] NSSet<NSString> contactFields);
	}

	// @interface STPCoreViewController : UIViewController
	[BaseType(typeof(UIViewController))]
	interface STPCoreViewController
	{
		// -(instancetype _Nonnull)initWithTheme:(STPTheme * _Nonnull)theme __attribute__((objc_designated_initializer));
		[Export("initWithTheme:")]
		[DesignatedInitializer]
		IntPtr Constructor(STPTheme theme);

		// -(instancetype _Nonnull)initWithNibName:(NSString * _Nullable)nibNameOrNil bundle:(NSBundle * _Nullable)nibBundleOrNil __attribute__((objc_designated_initializer));
		[Export("initWithNibName:bundle:")]
		[DesignatedInitializer]
		IntPtr Constructor([NullAllowed] string nibNameOrNil, [NullAllowed] NSBundle nibBundleOrNil);
	}

	// @interface STPCoreScrollViewController : STPCoreViewController
	[BaseType(typeof(STPCoreViewController))]
	interface STPCoreScrollViewController
	{
	}

	// @interface STPCoreTableViewController : STPCoreScrollViewController
	[BaseType(typeof(STPCoreScrollViewController))]
	interface STPCoreTableViewController
	{
	}

	// @protocol STPSourceProtocol <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol]
	[BaseType(typeof(NSObject))]
	interface STPSourceProtocol
	{
		// @required @property (readonly, nonatomic) NSString * _Nonnull stripeID;
		[Abstract]
		[Export("stripeID")]
		string StripeID { get; }
	}

	// @interface STPCustomer : NSObject <STPAPIResponseDecodable>
	[BaseType(typeof(NSObject))]
	interface STPCustomer
	{
		// +(instancetype _Nonnull)customerWithStripeID:(NSString * _Nonnull)stripeID defaultSource:(id<STPSourceProtocol> _Nullable)defaultSource sources:(NSArray<id<STPSourceProtocol>> * _Nonnull)sources;
		[Static]
		[Export("customerWithStripeID:defaultSource:sources:")]
		STPCustomer CustomerWithStripeID(string stripeID, [NullAllowed] STPSourceProtocol defaultSource, STPSourceProtocol[] sources);

		// @property (readonly, copy, nonatomic) NSString * _Nonnull stripeID;
		[Export("stripeID")]
		string StripeID { get; }

		// @property (readonly, nonatomic) id<STPSourceProtocol> _Nullable defaultSource;
		[NullAllowed, Export("defaultSource")]
		STPSourceProtocol DefaultSource { get; }

		// @property (readonly, nonatomic) NSArray<id<STPSourceProtocol>> * _Nonnull sources;
		[Export("sources")]
		STPSourceProtocol[] Sources { get; }

		// @property (readonly, nonatomic) STPAddress * _Nullable shippingAddress;
		[NullAllowed, Export("shippingAddress")]
		STPAddress ShippingAddress { get; }
	}

	// @interface STPCustomerDeserializer : NSObject
	[BaseType(typeof(NSObject))]
	interface STPCustomerDeserializer
	{
		// -(instancetype _Nonnull)initWithData:(NSData * _Nullable)data urlResponse:(NSURLResponse * _Nullable)urlResponse error:(NSError * _Nullable)error;
		[Export("initWithData:urlResponse:error:")]
		IntPtr Constructor([NullAllowed] NSData data, [NullAllowed] NSUrlResponse urlResponse, [NullAllowed] NSError error);

		// -(instancetype _Nonnull)initWithJSONResponse:(id _Nonnull)json;
		[Export("initWithJSONResponse:")]
		IntPtr Constructor(NSObject json);

		// @property (readonly, nonatomic) STPCustomer * _Nullable customer;
		[NullAllowed, Export("customer")]
		STPCustomer Customer { get; }

		// @property (readonly, nonatomic) NSError * _Nullable error;
		[NullAllowed, Export("error")]
		NSError Error { get; }
	}

	// @protocol STPBackendAPIAdapter <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol]
	[BaseType(typeof(NSObject))]
	interface STPBackendAPIAdapter
	{
		// @required -(void)retrieveCustomer:(STPCustomerCompletionBlock _Nullable)completion;
		[Abstract]
		[Export("retrieveCustomer:")]
		void RetrieveCustomer([NullAllowed] STPCustomerCompletionBlock completion);

		// @required -(void)listPaymentMethodsForCustomerWithCompletion:(STPPaymentMethodsCompletionBlock _Nullable)completion;
		[Abstract]
		[Export("listPaymentMethodsForCustomerWithCompletion:")]
		void ListPaymentMethodsForCustomerWithCompletion([NullAllowed] STPPaymentMethodsCompletionBlock completion);

		// @required -(void)attachPaymentMethodToCustomer:(STPPaymentMethod * _Nonnull)paymentMethod completion:(STPErrorBlock _Nullable)completion;
		[Abstract]
		[Export("attachPaymentMethodToCustomer:completion:")]
		void AttachPaymentMethodToCustomer(STPPaymentMethod paymentMethod, [NullAllowed] STPErrorBlock completion);

		// @optional -(void)detachPaymentMethodFromCustomer:(STPPaymentMethod * _Nonnull)paymentMethod completion:(STPErrorBlock _Nullable)completion;
		[Export("detachPaymentMethodFromCustomer:completion:")]
		void DetachPaymentMethodFromCustomer(STPPaymentMethod paymentMethod, [NullAllowed] STPErrorBlock completion);

		// @optional -(void)updateCustomerWithShippingAddress:(STPAddress * _Nonnull)shipping completion:(STPErrorBlock _Nullable)completion;
		[Export("updateCustomerWithShippingAddress:completion:")]
		void UpdateCustomerWithShippingAddress(STPAddress shipping, [NullAllowed] STPErrorBlock completion);
	}

	// @protocol STPPaymentOption <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol]
	[BaseType(typeof(NSObject))]
	interface STPPaymentOption
	{
		// @required @property (readonly, nonatomic, strong) UIImage * _Nonnull image;
		[Abstract]
		[Export("image", ArgumentSemantic.Strong)]
		UIImage Image { get; }

		// @required @property (readonly, nonatomic, strong) UIImage * _Nonnull templateImage;
		[Abstract]
		[Export("templateImage", ArgumentSemantic.Strong)]
		UIImage TemplateImage { get; }

		// @required @property (readonly, nonatomic, strong) NSString * _Nonnull label;
		[Abstract]
		[Export("label", ArgumentSemantic.Strong)]
		string Label { get; }

		// @required @property (readonly, getter = isReusable, nonatomic) BOOL reusable;
		[Abstract]
		[Export("reusable")]
		bool Reusable { [Bind("isReusable")] get; }
	}

	// @interface STPTheme : NSObject <NSCopying>
	[BaseType(typeof(NSObject))]
	interface STPTheme : INSCopying
	{
		// +(STPTheme * _Nonnull)defaultTheme;
		[Static]
		[Export("defaultTheme")]
		STPTheme DefaultTheme { get; }

		// @property (copy, nonatomic, null_resettable) UIColor * _Null_unspecified primaryBackgroundColor;
		[NullAllowed, Export("primaryBackgroundColor", ArgumentSemantic.Copy)]
		UIColor PrimaryBackgroundColor { get; set; }

		// @property (copy, nonatomic, null_resettable) UIColor * _Null_unspecified secondaryBackgroundColor;
		[NullAllowed, Export("secondaryBackgroundColor", ArgumentSemantic.Copy)]
		UIColor SecondaryBackgroundColor { get; set; }

		// @property (readonly, nonatomic) UIColor * _Nonnull tertiaryBackgroundColor;
		[Export("tertiaryBackgroundColor")]
		UIColor TertiaryBackgroundColor { get; }

		// @property (readonly, nonatomic) UIColor * _Nonnull quaternaryBackgroundColor;
		[Export("quaternaryBackgroundColor")]
		UIColor QuaternaryBackgroundColor { get; }

		// @property (copy, nonatomic, null_resettable) UIColor * _Null_unspecified primaryForegroundColor;
		[NullAllowed, Export("primaryForegroundColor", ArgumentSemantic.Copy)]
		UIColor PrimaryForegroundColor { get; set; }

		// @property (copy, nonatomic, null_resettable) UIColor * _Null_unspecified secondaryForegroundColor;
		[NullAllowed, Export("secondaryForegroundColor", ArgumentSemantic.Copy)]
		UIColor SecondaryForegroundColor { get; set; }

		// @property (readonly, nonatomic) UIColor * _Nonnull tertiaryForegroundColor;
		[Export("tertiaryForegroundColor")]
		UIColor TertiaryForegroundColor { get; }

		// @property (copy, nonatomic, null_resettable) UIColor * _Null_unspecified accentColor;
		[NullAllowed, Export("accentColor", ArgumentSemantic.Copy)]
		UIColor AccentColor { get; set; }

		// @property (copy, nonatomic, null_resettable) UIColor * _Null_unspecified errorColor;
		[NullAllowed, Export("errorColor", ArgumentSemantic.Copy)]
		UIColor ErrorColor { get; set; }

		// @property (copy, nonatomic, null_resettable) UIFont * _Null_unspecified font;
		[NullAllowed, Export("font", ArgumentSemantic.Copy)]
		UIFont Font { get; set; }

		// @property (copy, nonatomic, null_resettable) UIFont * _Null_unspecified emphasisFont;
		[NullAllowed, Export("emphasisFont", ArgumentSemantic.Copy)]
		UIFont EmphasisFont { get; set; }

		// @property (nonatomic) UIBarStyle barStyle;
		[Export("barStyle", ArgumentSemantic.Assign)]
		UIBarStyle BarStyle { get; set; }

		// @property (nonatomic) BOOL translucentNavigationBar;
		[Export("translucentNavigationBar")]
		bool TranslucentNavigationBar { get; set; }

		// @property (readonly, nonatomic) UIFont * _Nonnull smallFont;
		[Export("smallFont")]
		UIFont SmallFont { get; }

		// @property (readonly, nonatomic) UIFont * _Nonnull largeFont;
		[Export("largeFont")]
		UIFont LargeFont { get; }
	}

	// @interface STPPaymentConfiguration : NSObject <NSCopying>
	[BaseType(typeof(NSObject))]
	interface STPPaymentConfiguration : INSCopying
	{
		// +(instancetype _Nonnull)sharedConfiguration;
		[Static]
		[Export("sharedConfiguration")]
		STPPaymentConfiguration SharedConfiguration();

		// @property (assign, readwrite, nonatomic) STPPaymentOptionType additionalPaymentOptions;
		[Export("additionalPaymentOptions", ArgumentSemantic.Assign)]
		STPPaymentOptionType AdditionalPaymentOptions { get; set; }

		// @property (assign, readwrite, nonatomic) STPBillingAddressFields requiredBillingAddressFields;
		[Export("requiredBillingAddressFields", ArgumentSemantic.Assign)]
		STPBillingAddressFields RequiredBillingAddressFields { get; set; }

		// @property (readwrite, copy, nonatomic) NSSet<STPContactField> * _Nullable requiredShippingAddressFields;
		[NullAllowed, Export("requiredShippingAddressFields", ArgumentSemantic.Copy)]
		NSSet<NSString> RequiredShippingAddressFields { get; set; }

		// @property (assign, readwrite, nonatomic) BOOL verifyPrefilledShippingAddress;
		[Export("verifyPrefilledShippingAddress")]
		bool VerifyPrefilledShippingAddress { get; set; }

		// @property (assign, readwrite, nonatomic) STPShippingType shippingType;
		[Export("shippingType", ArgumentSemantic.Assign)]
		STPShippingType ShippingType { get; set; }

		// @property (readwrite, copy, nonatomic, null_resettable) NSSet<NSString *> * _Null_unspecified availableCountries;
		[NullAllowed, Export("availableCountries", ArgumentSemantic.Copy)]
		NSSet<NSString> AvailableCountries { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * _Nonnull companyName;
		[Export("companyName")]
		string CompanyName { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * _Nullable appleMerchantIdentifier;
		[NullAllowed, Export("appleMerchantIdentifier")]
		string AppleMerchantIdentifier { get; set; }

		// @property (assign, readwrite, nonatomic) BOOL canDeletePaymentOptions;
		[Export("canDeletePaymentOptions")]
		bool CanDeletePaymentOptions { get; set; }

		// @property (readwrite, copy, nonatomic) DEPRECATED_MSG_ATTRIBUTE("If you used [STPPaymentConfiguration sharedConfiguration].publishableKey, use [STPAPIClient sharedClient].publishableKey instead. If you passed a STPPaymentConfiguration instance to an SDK component, create an STPAPIClient, set publishableKey on it, and set the SDK component's APIClient property.") NSString * publishableKey __attribute__((deprecated("If you used [STPPaymentConfiguration sharedConfiguration].publishableKey, use [STPAPIClient sharedClient].publishableKey instead. If you passed a STPPaymentConfiguration instance to an SDK component, create an STPAPIClient, set publishableKey on it, and set the SDK component's APIClient property.")));
		[Export("publishableKey")]
		string PublishableKey { get; set; }

		// @property (copy, nonatomic) DEPRECATED_MSG_ATTRIBUTE("If you used [STPPaymentConfiguration sharedConfiguration].stripeAccount, use [STPAPIClient sharedClient].stripeAccount instead. If you passed a STPPaymentConfiguration instance to an SDK component, create an STPAPIClient, set stripeAccount on it, and set the SDK component's APIClient property.") NSString * stripeAccount __attribute__((deprecated("If you used [STPPaymentConfiguration sharedConfiguration].stripeAccount, use [STPAPIClient sharedClient].stripeAccount instead. If you passed a STPPaymentConfiguration instance to an SDK component, create an STPAPIClient, set stripeAccount on it, and set the SDK component's APIClient property.")));
		[Export("stripeAccount")]
		string StripeAccount { get; set; }
	}

	// @interface STPUserInformation : NSObject <NSCopying>
	[BaseType(typeof(NSObject))]
	interface STPUserInformation : INSCopying
	{
		// @property (nonatomic, strong) STPAddress * _Nullable billingAddress;
		[NullAllowed, Export("billingAddress", ArgumentSemantic.Strong)]
		STPAddress BillingAddress { get; set; }

		// @property (nonatomic, strong) STPAddress * _Nullable shippingAddress;
		[NullAllowed, Export("shippingAddress", ArgumentSemantic.Strong)]
		STPAddress ShippingAddress { get; set; }

		// -(void)setBillingAddressWithBillingDetails:(STPPaymentMethodBillingDetails * _Nonnull)billingDetails __attribute__((swift_name("setBillingAddress(with:)")));
		[Export("setBillingAddressWithBillingDetails:")]
		void SetBillingAddressWithBillingDetails(STPPaymentMethodBillingDetails billingDetails);
	}

	// @interface STPAddCardViewController : STPCoreTableViewController
	[BaseType(typeof(STPCoreTableViewController))]
	interface STPAddCardViewController
	{
		// -(instancetype _Nonnull)initWithConfiguration:(STPPaymentConfiguration * _Nonnull)configuration theme:(STPTheme * _Nonnull)theme;
		[Export("initWithConfiguration:theme:")]
		IntPtr Constructor(STPPaymentConfiguration configuration, STPTheme theme);

		[Wrap("WeakDelegate")]
		[NullAllowed]
		STPAddCardViewControllerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<STPAddCardViewControllerDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (nonatomic, strong) STPUserInformation * _Nullable prefilledInformation;
		[NullAllowed, Export("prefilledInformation", ArgumentSemantic.Strong)]
		STPUserInformation PrefilledInformation { get; set; }

		// @property (nonatomic, strong) UIView * _Nullable customFooterView;
		[NullAllowed, Export("customFooterView", ArgumentSemantic.Strong)]
		UIView CustomFooterView { get; set; }

		// @property (nonatomic, strong) STPAPIClient * _Nonnull apiClient;
		[Export("apiClient", ArgumentSemantic.Strong)]
		STPAPIClient ApiClient { get; set; }
	}

	// @protocol STPAddCardViewControllerDelegate <NSObject>
	[Protocol, Model(AutoGeneratedName = true)]
	[BaseType(typeof(NSObject))]
	interface STPAddCardViewControllerDelegate
	{
		// @required -(void)addCardViewControllerDidCancel:(STPAddCardViewController * _Nonnull)addCardViewController;
		[Abstract]
		[Export("addCardViewControllerDidCancel:")]
		void AddCardViewControllerDidCancel(STPAddCardViewController addCardViewController);

		// @optional -(void)addCardViewController:(STPAddCardViewController * _Nonnull)addCardViewController didCreatePaymentMethod:(STPPaymentMethod * _Nonnull)paymentMethod completion:(STPErrorBlock _Nonnull)completion;
		[Export("addCardViewController:didCreatePaymentMethod:completion:")]
		void AddCardViewController(STPAddCardViewController addCardViewController, STPPaymentMethod paymentMethod, STPErrorBlock completion);

		// @optional -(void)addCardViewController:(STPAddCardViewController * _Nonnull)addCardViewController didCreateToken:(STPToken * _Nonnull)token completion:(STPErrorBlock _Nonnull)completion __attribute__((deprecated("Use addCardViewController:didCreatePaymentMethod:completion: instead and migrate your integration to PaymentIntents. See https://stripe.com/docs/payments/payment-intents/migration/charges#read", "addCardViewController:didCreatePaymentMethod:completion:")));
		[Export("addCardViewController:didCreateToken:completion:")]
		void AddCardViewController(STPAddCardViewController addCardViewController, STPToken token, STPErrorBlock completion);

		// @optional -(void)addCardViewController:(STPAddCardViewController * _Nonnull)addCardViewController didCreateSource:(STPSource * _Nonnull)source completion:(STPErrorBlock _Nonnull)completion __attribute__((deprecated("Use addCardViewController:didCreatePaymentMethod:completion: instead and migrate your integration to PaymentIntents. See https://stripe.com/docs/payments/payment-intents/migration/charges#read", "addCardViewController:didCreatePaymentMethod:completion:")));
		[Export("addCardViewController:didCreateSource:completion:")]
		void AddCardViewController(STPAddCardViewController addCardViewController, STPSource source, STPErrorBlock completion);
	}

	// @interface STPAppInfo : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface STPAppInfo
	{
		// -(instancetype _Nonnull)initWithName:(NSString * _Nonnull)name partnerId:(NSString * _Nonnull)partnerId version:(NSString * _Nullable)version url:(NSString * _Nullable)url;
		[Export("initWithName:partnerId:version:url:")]
		IntPtr Constructor(string name, string partnerId, [NullAllowed] string version, [NullAllowed] string url);

		// @property (readonly, nonatomic) NSString * _Nonnull name;
		[Export("name")]
		string Name { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull partnerId;
		[Export("partnerId")]
		string PartnerId { get; }

		// @property (readonly, nonatomic) NSString * _Nullable version;
		[NullAllowed, Export("version")]
		string Version { get; }

		// @property (readonly, nonatomic) NSString * _Nullable url;
		[NullAllowed, Export("url")]
		string Url { get; }
	}

	// @protocol STPApplePayContextDelegate <NSObject>
	[Protocol, Model(AutoGeneratedName = true)]
	[BaseType(typeof(NSObject))]
	interface STPApplePayContextDelegate
	{
		// @required -(void)applePayContext:(STPApplePayContext * _Nonnull)context didCreatePaymentMethod:(STPPaymentMethod * _Nonnull)paymentMethod paymentInformation:(PKPayment * _Nonnull)paymentInformation completion:(STPIntentClientSecretCompletionBlock _Nonnull)completion;
		[Abstract]
		[Export("applePayContext:didCreatePaymentMethod:paymentInformation:completion:")]
		void DidCreatePaymentMethod(STPApplePayContext context, STPPaymentMethod paymentMethod, PKPayment paymentInformation, STPIntentClientSecretCompletionBlock completion);

		// @required -(void)applePayContext:(STPApplePayContext * _Nonnull)context didCompleteWithStatus:(STPPaymentStatus)status error:(NSError * _Nullable)error;
		[Abstract]
		[Export("applePayContext:didCompleteWithStatus:error:")]
		void DidCompleteWithStatus(STPApplePayContext context, STPPaymentStatus status, [NullAllowed] NSError error);

		// @optional -(void)applePayContext:(STPApplePayContext * _Nonnull)context didSelectShippingMethod:(PKShippingMethod * _Nonnull)shippingMethod handler:(void (^ _Nonnull)(PKPaymentRequestShippingMethodUpdate * _Nonnull))handler __attribute__((availability(ios, introduced=11.0))) __attribute__((availability(watchos, introduced=4.0)));
		[Watch(4, 0), iOS(11, 0)]
		[Export("applePayContext:didSelectShippingMethod:handler:")]
		void DidSelectShippingMethod(STPApplePayContext context, PKShippingMethod shippingMethod, Action<PKPaymentRequestShippingMethodUpdate> handler);

		// @optional -(void)applePayContext:(STPApplePayContext * _Nonnull)context didSelectShippingContact:(PKContact * _Nonnull)contact handler:(void (^ _Nonnull)(PKPaymentRequestShippingContactUpdate * _Nonnull))handler __attribute__((availability(ios, introduced=11.0))) __attribute__((availability(watchos, introduced=4.0)));
		[Watch(4, 0), iOS(11, 0)]
		[Export("applePayContext:didSelectShippingContact:handler:")]
		void DidSelectShippingContact(STPApplePayContext context, PKContact contact, Action<PKPaymentRequestShippingContactUpdate> handler);

		// @optional -(void)applePayContext:(STPApplePayContext * _Nonnull)context didSelectShippingContact:(PKContact * _Nonnull)contact completion:(void (^ _Nonnull)(PKPaymentAuthorizationStatus, NSArray<PKShippingMethod *> * _Nonnull, NSArray<PKPaymentSummaryItem *> * _Nonnull))completion __attribute__((availability(ios, introduced=9.0, deprecated=11.0)));
		[Introduced(PlatformName.iOS, 9, 0, message: "Use paymentAuthorizationViewController:didSelectShippingContact:handler: instead to provide more granular errors")]
		[Deprecated(PlatformName.iOS, 11, 0, message: "Use paymentAuthorizationViewController:didSelectShippingContact:handler: instead to provide more granular errors")]
		[Export("applePayContext:didSelectShippingContact:completion:")]
		void DidSelectShippingContact(STPApplePayContext context, PKContact contact, Action<PKPaymentAuthorizationStatus, NSArray<PKShippingMethod>, NSArray<PKPaymentSummaryItem>> completion);

		// @optional -(void)applePayContext:(STPApplePayContext * _Nonnull)context didSelectShippingMethod:(PKShippingMethod * _Nonnull)shippingMethod completion:(void (^ _Nonnull)(PKPaymentAuthorizationStatus, NSArray<PKPaymentSummaryItem *> * _Nonnull))completion __attribute__((availability(ios, introduced=8.0, deprecated=11.0)));
		[Introduced(PlatformName.iOS, 8, 0, message: "Use paymentAuthorizationViewController:didSelectShippingMethod:handler: instead to provide more granular errors")]
		[Deprecated(PlatformName.iOS, 11, 0, message: "Use paymentAuthorizationViewController:didSelectShippingMethod:handler: instead to provide more granular errors")]
		[Export("applePayContext:didSelectShippingMethod:completion:")]
		void DidSelectShippingMethod(STPApplePayContext context, PKShippingMethod shippingMethod, Action<PKPaymentAuthorizationStatus, NSArray<PKPaymentSummaryItem>> completion);
	}

	// @interface STPApplePayContext : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface STPApplePayContext
	{
		// -(instancetype _Nullable)initWithPaymentRequest:(PKPaymentRequest * _Nonnull)paymentRequest delegate:(id<STPApplePayContextDelegate> _Nonnull)delegate;
		[Export("initWithPaymentRequest:delegate:")]
		IntPtr Constructor(PKPaymentRequest paymentRequest, STPApplePayContextDelegate @delegate);

		// -(void)presentApplePayOnViewController:(UIViewController * _Nonnull)viewController completion:(STPVoidBlock _Nullable)completion;
		[Export("presentApplePayOnViewController:completion:")]
		void PresentApplePayOnViewController(UIViewController viewController, [NullAllowed] STPVoidBlock completion);

		// @property (nonatomic, null_resettable) STPAPIClient * _Null_unspecified apiClient;
		[NullAllowed, Export("apiClient", ArgumentSemantic.Assign)]
		STPAPIClient ApiClient { get; set; }
	}

	// @protocol STPAuthenticationContext <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol]
	[BaseType(typeof(NSObject))]
	interface STPAuthenticationContext
	{
		// @required -(UIViewController * _Nonnull)authenticationPresentingViewController;
		[Abstract]
		[Export("authenticationPresentingViewController")]
		UIViewController AuthenticationPresentingViewController { get; }

		// @optional -(void)prepareAuthenticationContextForPresentation:(STPVoidBlock _Nonnull)completion;
		[Export("prepareAuthenticationContextForPresentation:")]
		void PrepareAuthenticationContextForPresentation(STPVoidBlock completion);

		// @optional -(void)configureSafariViewController:(SFSafariViewController * _Nonnull)viewController;
		[Export("configureSafariViewController:")]
		void ConfigureSafariViewController(SFSafariViewController viewController);

		// @optional -(void)authenticationContextWillDismissViewController:(UIViewController * _Nonnull)viewController;
		[Export("authenticationContextWillDismissViewController:")]
		void AuthenticationContextWillDismissViewController(UIViewController viewController);
	}

	// @interface STPIssuingCardPin : NSObject <STPAPIResponseDecodable>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface STPIssuingCardPin
	{
		// @property (readonly, nonatomic) NSString * _Nullable pin;
		[NullAllowed, Export("pin")]
		string Pin { get; }

		// @property (readonly, nonatomic) NSDictionary * _Nullable error;
		[NullAllowed, Export("error")]
		NSDictionary Error { get; }
	}

	// @protocol STPCustomerEphemeralKeyProvider <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol]
	[BaseType(typeof(NSObject))]
	interface STPCustomerEphemeralKeyProvider
	{
		// @required -(void)createCustomerKeyWithAPIVersion:(NSString * _Nonnull)apiVersion completion:(STPJSONResponseCompletionBlock _Nonnull)completion;
		[Abstract]
		[Export("createCustomerKeyWithAPIVersion:completion:")]
		void Completion(string apiVersion, STPJSONResponseCompletionBlock completion);
	}

	// @protocol STPIssuingCardEphemeralKeyProvider <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol]
	[BaseType(typeof(NSObject))]
	interface STPIssuingCardEphemeralKeyProvider
	{
		// @required -(void)createIssuingCardKeyWithAPIVersion:(NSString * _Nonnull)apiVersion completion:(STPJSONResponseCompletionBlock _Nonnull)completion;
		[Abstract]
		[Export("createIssuingCardKeyWithAPIVersion:completion:")]
		void Completion(string apiVersion, STPJSONResponseCompletionBlock completion);
	}

	// @protocol STPEphemeralKeyProvider <STPCustomerEphemeralKeyProvider>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol]
	interface STPEphemeralKeyProvider : STPCustomerEphemeralKeyProvider
	{
	}

	// @interface ApplePay (STPAPIClient)
	[Category]
	[BaseType(typeof(STPAPIClient))]
	interface STPAPIClient_ApplePay
	{
		// -(void)createTokenWithPayment:(PKPayment * _Nonnull)payment completion:(STPTokenCompletionBlock _Nonnull)completion;
		[Export("createTokenWithPayment:completion:")]
		void CreateTokenWithPayment(PKPayment payment, STPTokenCompletionBlock completion);

		// -(void)createSourceWithPayment:(PKPayment * _Nonnull)payment completion:(STPSourceCompletionBlock _Nonnull)completion;
		[Export("createSourceWithPayment:completion:")]
		void CreateSourceWithPayment(PKPayment payment, STPSourceCompletionBlock completion);

		// -(void)createPaymentMethodWithPayment:(PKPayment * _Nonnull)payment completion:(STPPaymentMethodCompletionBlock _Nonnull)completion;
		[Export("createPaymentMethodWithPayment:completion:")]
		void CreatePaymentMethodWithPayment(PKPayment payment, STPPaymentMethodCompletionBlock completion);

		// +(NSError * _Nullable)pkPaymentErrorForStripeError:(NSError * _Nullable)stripeError __attribute__((availability(ios, introduced=11.0))) __attribute__((availability(watchos, introduced=4.0)));
		[Watch(4, 0), iOS(11, 0)]
		[Static]
		[Export("pkPaymentErrorForStripeError:")]
		[return: NullAllowed]
		NSError PkPaymentErrorForStripeError([NullAllowed] NSError stripeError);
	}

	// @interface STPApplePayPaymentOption : NSObject <STPPaymentOption>
	[BaseType(typeof(NSObject))]
	interface STPApplePayPaymentOption : STPPaymentOption
	{
	}

	// @interface STPBankAccountParams : NSObject <STPFormEncodable>
	[BaseType(typeof(NSObject))]
	interface STPBankAccountParams
	{
		// @property (copy, nonatomic) NSString * _Nullable accountNumber;
		[NullAllowed, Export("accountNumber")]
		string AccountNumber { get; set; }

		// @property (readonly, nonatomic) NSString * _Nullable last4;
		[NullAllowed, Export("last4")]
		string Last4 { get; }

		// @property (copy, nonatomic) NSString * _Nullable routingNumber;
		[NullAllowed, Export("routingNumber")]
		string RoutingNumber { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable country;
		[NullAllowed, Export("country")]
		string Country { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable currency;
		[NullAllowed, Export("currency")]
		string Currency { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable accountHolderName;
		[NullAllowed, Export("accountHolderName")]
		string AccountHolderName { get; set; }

		// @property (assign, nonatomic) STPBankAccountHolderType accountHolderType;
		[Export("accountHolderType", ArgumentSemantic.Assign)]
		STPBankAccountHolderType AccountHolderType { get; set; }
	}

	// @interface STPBankAccount : NSObject <STPAPIResponseDecodable, STPSourceProtocol>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface STPBankAccount : STPSourceProtocol
	{
		// @property (readonly, nonatomic) NSString * _Nullable routingNumber;
		[NullAllowed, Export("routingNumber")]
		string RoutingNumber { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull country;
		[Export("country")]
		string Country { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull currency;
		[Export("currency")]
		string Currency { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull last4;
		[Export("last4")]
		string Last4 { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull bankName;
		[Export("bankName")]
		string BankName { get; }

		// @property (readonly, nonatomic) NSString * _Nullable accountHolderName;
		[NullAllowed, Export("accountHolderName")]
		string AccountHolderName { get; }

		// @property (readonly, nonatomic) STPBankAccountHolderType accountHolderType;
		[Export("accountHolderType")]
		STPBankAccountHolderType AccountHolderType { get; }

		// @property (readonly, nonatomic) NSString * _Nullable fingerprint;
		[NullAllowed, Export("fingerprint")]
		string Fingerprint { get; }

		// @property (readonly, nonatomic) STPBankAccountStatus status;
		[Export("status")]
		STPBankAccountStatus Status { get; }

		// @property (readonly, nonatomic) DEPRECATED_MSG_ATTRIBUTE("Metadata is no longer returned to clients using publishable keys. Retrieve them on your server using yoursecret key instead.") NSDictionary<NSString *,NSString *> * metadata __attribute__((deprecated("Metadata is no longer returned to clients using publishable keys. Retrieve them on your server using yoursecret key instead.")));
		[Export("metadata")]
		NSDictionary<NSString, NSString> Metadata { get; }

		// @property (readonly, nonatomic) DEPRECATED_MSG_ATTRIBUTE("Use stripeID (defined in STPSourceProtocol)") NSString * bankAccountId __attribute__((deprecated("Use stripeID (defined in STPSourceProtocol)")));
		[Export("bankAccountId")]
		string BankAccountId { get; }
	}

	// @interface STPBankSelectionViewController : STPCoreTableViewController
	[BaseType(typeof(STPCoreTableViewController))]
	interface STPBankSelectionViewController
	{
		// -(instancetype _Nonnull)initWithBankMethod:(STPBankSelectionMethod)bankMethod;
		[Export("initWithBankMethod:")]
		IntPtr Constructor(STPBankSelectionMethod bankMethod);

		// -(instancetype _Nonnull)initWithBankMethod:(STPBankSelectionMethod)bankMethod configuration:(STPPaymentConfiguration * _Nonnull)configuration theme:(STPTheme * _Nonnull)theme;
		[Export("initWithBankMethod:configuration:theme:")]
		IntPtr Constructor(STPBankSelectionMethod bankMethod, STPPaymentConfiguration configuration, STPTheme theme);

		[Wrap("WeakDelegate")]
		[NullAllowed]
		STPBankSelectionViewControllerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<STPBankSelectionViewControllerDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (nonatomic, strong) STPAPIClient * _Nonnull apiClient;
		[Export("apiClient", ArgumentSemantic.Strong)]
		STPAPIClient ApiClient { get; set; }
	}

	// @protocol STPBankSelectionViewControllerDelegate <NSObject>
	[Protocol, Model(AutoGeneratedName = true)]
	[BaseType(typeof(NSObject))]
	interface STPBankSelectionViewControllerDelegate
	{
		// @required -(void)bankSelectionViewController:(STPBankSelectionViewController * _Nonnull)bankViewController didCreatePaymentMethodParams:(STPPaymentMethodParams * _Nonnull)paymentMethodParams;
		[Abstract]
		[Export("bankSelectionViewController:didCreatePaymentMethodParams:")]
		void DidCreatePaymentMethodParams(STPBankSelectionViewController bankViewController, STPPaymentMethodParams paymentMethodParams);
	}

	// @interface STPCardParams : NSObject <STPFormEncodable, NSCopying>
	[BaseType(typeof(NSObject))]
	interface STPCardParams : INSCopying
	{
		// @property (copy, nonatomic) NSString * _Nullable number;
		[NullAllowed, Export("number")]
		string Number { get; set; }

		// -(NSString * _Nullable)last4;
		[NullAllowed, Export("last4")]
		string Last4 { get; }

		// @property (nonatomic) NSUInteger expMonth;
		[Export("expMonth")]
		nuint ExpMonth { get; set; }

		// @property (nonatomic) NSUInteger expYear;
		[Export("expYear")]
		nuint ExpYear { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable cvc;
		[NullAllowed, Export("cvc")]
		string Cvc { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export("name")]
		string Name { get; set; }

		// @property (nonatomic, strong) STPAddress * _Nonnull address;
		[Export("address", ArgumentSemantic.Strong)]
		STPAddress Address { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable currency;
		[NullAllowed, Export("currency")]
		string Currency { get; set; }

		// @property (copy, nonatomic) DEPRECATED_MSG_ATTRIBUTE("Use address.line1") NSString * addressLine1 __attribute__((deprecated("Use address.line1")));
		[Export("addressLine1")]
		string AddressLine1 { get; set; }

		// @property (copy, nonatomic) DEPRECATED_MSG_ATTRIBUTE("Use address.line2") NSString * addressLine2 __attribute__((deprecated("Use address.line2")));
		[Export("addressLine2")]
		string AddressLine2 { get; set; }

		// @property (copy, nonatomic) DEPRECATED_MSG_ATTRIBUTE("Use address.city") NSString * addressCity __attribute__((deprecated("Use address.city")));
		[Export("addressCity")]
		string AddressCity { get; set; }

		// @property (copy, nonatomic) DEPRECATED_MSG_ATTRIBUTE("Use address.state") NSString * addressState __attribute__((deprecated("Use address.state")));
		[Export("addressState")]
		string AddressState { get; set; }

		// @property (copy, nonatomic) DEPRECATED_MSG_ATTRIBUTE("Use address.postalCode") NSString * addressZip __attribute__((deprecated("Use address.postalCode")));
		[Export("addressZip")]
		string AddressZip { get; set; }

		// @property (copy, nonatomic) DEPRECATED_MSG_ATTRIBUTE("Use address.country") NSString * addressCountry __attribute__((deprecated("Use address.country")));
		[Export("addressCountry")]
		string AddressCountry { get; set; }
	}

	// @interface STPCard : NSObject <STPAPIResponseDecodable, STPPaymentOption, STPSourceProtocol>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface STPCard : STPPaymentOption, STPSourceProtocol
	{
		// @property (readonly, nonatomic) NSString * _Nonnull last4;
		[Export("last4")]
		string Last4 { get; }

		// @property (readonly, nonatomic) NSString * _Nullable dynamicLast4;
		[NullAllowed, Export("dynamicLast4")]
		string DynamicLast4 { get; }

		// @property (readonly, nonatomic) BOOL isApplePayCard;
		[Export("isApplePayCard")]
		bool IsApplePayCard { get; }

		// @property (readonly, nonatomic) NSUInteger expMonth;
		[Export("expMonth")]
		nuint ExpMonth { get; }

		// @property (readonly, nonatomic) NSUInteger expYear;
		[Export("expYear")]
		nuint ExpYear { get; }

		// @property (readonly, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export("name")]
		string Name { get; }

		// @property (readonly, nonatomic) STPAddress * _Nonnull address;
		[Export("address")]
		STPAddress Address { get; }

		// @property (readonly, nonatomic) STPCardBrand brand;
		[Export("brand")]
		STPCardBrand Brand { get; }

		// @property (readonly, nonatomic) STPCardFundingType funding;
		[Export("funding")]
		STPCardFundingType Funding { get; }

		// @property (readonly, nonatomic) NSString * _Nullable country;
		[NullAllowed, Export("country")]
		string Country { get; }

		// @property (readonly, nonatomic) NSString * _Nullable currency;
		[NullAllowed, Export("currency")]
		string Currency { get; }

		// +(NSString * _Nonnull)stringFromBrand:(STPCardBrand)brand;
		[Static]
		[Export("stringFromBrand:")]
		string StringFromBrand(STPCardBrand brand);

		// +(STPCardBrand)brandFromString:(NSString * _Nonnull)string;
		[Static]
		[Export("brandFromString:")]
		STPCardBrand BrandFromString(string @string);

		// @property (readonly, nonatomic) DEPRECATED_MSG_ATTRIBUTE("Metadata is no longer returned to clients using publishable keys. Retrieve them on your server using yoursecret key instead.") NSDictionary<NSString *,NSString *> * metadata __attribute__((deprecated("Metadata is no longer returned to clients using publishable keys. Retrieve them on your server using yoursecret key instead.")));
		[Export("metadata")]
		NSDictionary<NSString, NSString> Metadata { get; }

		// @property (readonly, nonatomic) DEPRECATED_MSG_ATTRIBUTE("Use stripeID (defined in STPSourceProtocol)") NSString * cardId __attribute__((deprecated("Use stripeID (defined in STPSourceProtocol)")));
		[Export("cardId")]
		string CardId { get; }

		// @property (readonly, nonatomic) DEPRECATED_MSG_ATTRIBUTE("Use address.line1") NSString * addressLine1 __attribute__((deprecated("Use address.line1")));
		[Export("addressLine1")]
		string AddressLine1 { get; }

		// @property (readonly, nonatomic) DEPRECATED_MSG_ATTRIBUTE("Use address.line2") NSString * addressLine2 __attribute__((deprecated("Use address.line2")));
		[Export("addressLine2")]
		string AddressLine2 { get; }

		// @property (readonly, nonatomic) DEPRECATED_MSG_ATTRIBUTE("Use address.city") NSString * addressCity __attribute__((deprecated("Use address.city")));
		[Export("addressCity")]
		string AddressCity { get; }

		// @property (readonly, nonatomic) DEPRECATED_MSG_ATTRIBUTE("Use address.state") NSString * addressState __attribute__((deprecated("Use address.state")));
		[Export("addressState")]
		string AddressState { get; }

		// @property (readonly, nonatomic) DEPRECATED_MSG_ATTRIBUTE("Use address.postalCode") NSString * addressZip __attribute__((deprecated("Use address.postalCode")));
		[Export("addressZip")]
		string AddressZip { get; }

		// @property (readonly, nonatomic) DEPRECATED_MSG_ATTRIBUTE("Use address.country") NSString * addressCountry __attribute__((deprecated("Use address.country")));
		[Export("addressCountry")]
		string AddressCountry { get; }

		// -(instancetype _Nonnull)initWithID:(NSString * _Nonnull)cardID brand:(STPCardBrand)brand last4:(NSString * _Nonnull)last4 expMonth:(NSUInteger)expMonth expYear:(NSUInteger)expYear funding:(STPCardFundingType)funding __attribute__((deprecated("You cannot directly instantiate an STPCard. You should only use one that has been returned from an STPAPIClient callback.")));
		[Export("initWithID:brand:last4:expMonth:expYear:funding:")]
		IntPtr Constructor(string cardID, STPCardBrand brand, string last4, nuint expMonth, nuint expYear, STPCardFundingType funding);

		// +(STPCardFundingType)fundingFromString:(NSString * _Nonnull)string __attribute__((deprecated("")));
		[Static]
		[Export("fundingFromString:")]
		STPCardFundingType FundingFromString(string @string);
	}

	// @interface STPCardValidator : NSObject
	[BaseType(typeof(NSObject))]
	interface STPCardValidator
	{
		// +(NSString * _Nonnull)sanitizedNumericStringForString:(NSString * _Nonnull)string;
		[Static]
		[Export("sanitizedNumericStringForString:")]
		string SanitizedNumericStringForString(string @string);

		// +(NSString * _Nonnull)sanitizedPostalStringForString:(NSString * _Nonnull)string;
		[Static]
		[Export("sanitizedPostalStringForString:")]
		string SanitizedPostalStringForString(string @string);

		// +(BOOL)stringIsNumeric:(NSString * _Nonnull)string;
		[Static]
		[Export("stringIsNumeric:")]
		bool StringIsNumeric(string @string);

		// +(STPCardValidationState)validationStateForNumber:(NSString * _Nullable)cardNumber validatingCardBrand:(BOOL)validatingCardBrand;
		[Static]
		[Export("validationStateForNumber:validatingCardBrand:")]
		STPCardValidationState ValidationStateForNumber([NullAllowed] string cardNumber, bool validatingCardBrand);

		// +(STPCardBrand)brandForNumber:(NSString * _Nonnull)cardNumber;
		[Static]
		[Export("brandForNumber:")]
		STPCardBrand BrandForNumber(string cardNumber);

		// +(NSSet<NSNumber *> * _Nonnull)lengthsForCardBrand:(STPCardBrand)brand;
		[Static]
		[Export("lengthsForCardBrand:")]
		NSSet<NSNumber> LengthsForCardBrand(STPCardBrand brand);

		// +(NSInteger)maxLengthForCardBrand:(STPCardBrand)brand;
		[Static]
		[Export("maxLengthForCardBrand:")]
		nint MaxLengthForCardBrand(STPCardBrand brand);

		// +(NSInteger)fragmentLengthForCardBrand:(STPCardBrand)brand;
		[Static]
		[Export("fragmentLengthForCardBrand:")]
		nint FragmentLengthForCardBrand(STPCardBrand brand);

		// +(STPCardValidationState)validationStateForExpirationMonth:(NSString * _Nonnull)expirationMonth;
		[Static]
		[Export("validationStateForExpirationMonth:")]
		STPCardValidationState ValidationStateForExpirationMonth(string expirationMonth);

		// +(STPCardValidationState)validationStateForExpirationYear:(NSString * _Nonnull)expirationYear inMonth:(NSString * _Nonnull)expirationMonth;
		[Static]
		[Export("validationStateForExpirationYear:inMonth:")]
		STPCardValidationState ValidationStateForExpirationYear(string expirationYear, string expirationMonth);

		// +(NSUInteger)maxCVCLengthForCardBrand:(STPCardBrand)brand;
		[Static]
		[Export("maxCVCLengthForCardBrand:")]
		nuint MaxCVCLengthForCardBrand(STPCardBrand brand);

		// +(STPCardValidationState)validationStateForCVC:(NSString * _Nonnull)cvc cardBrand:(STPCardBrand)brand;
		[Static]
		[Export("validationStateForCVC:cardBrand:")]
		STPCardValidationState ValidationStateForCVC(string cvc, STPCardBrand brand);

		// +(STPCardValidationState)validationStateForCard:(STPCardParams * _Nonnull)card;
		[Static]
		[Export("validationStateForCard:")]
		STPCardValidationState ValidationStateForCard(STPCardParams card);
	}

	// @interface STPConfirmAlipayOptions : NSObject <STPFormEncodable>
	[BaseType(typeof(NSObject))]
	interface STPConfirmAlipayOptions
	{
		// @property (readonly, nonatomic) NSString * _Nonnull appBundleID;
		[Export("appBundleID")]
		string AppBundleID { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull appVersionKey;
		[Export("appVersionKey")]
		string AppVersionKey { get; }
	}

	// @interface STPConfirmCardOptions : NSObject <STPFormEncodable>
	[BaseType(typeof(NSObject))]
	interface STPConfirmCardOptions
	{
		// @property (copy, nonatomic) NSString * _Nullable cvc;
		[NullAllowed, Export("cvc")]
		string Cvc { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable network;
		[NullAllowed, Export("network")]
		string Network { get; set; }
	}

	// @interface STPConfirmPaymentMethodOptions : NSObject <STPFormEncodable>
	[BaseType(typeof(NSObject))]
	interface STPConfirmPaymentMethodOptions
	{
		// @property (nonatomic) STPConfirmCardOptions * _Nullable cardOptions;
		[NullAllowed, Export("cardOptions", ArgumentSemantic.Assign)]
		STPConfirmCardOptions CardOptions { get; set; }

		// @property (nonatomic) STPConfirmAlipayOptions * _Nullable alipayOptions;
		[NullAllowed, Export("alipayOptions", ArgumentSemantic.Assign)]
		STPConfirmAlipayOptions AlipayOptions { get; set; }
	}

	// @interface STPConnectAccountAddress : NSObject <STPFormEncodable>
	[BaseType(typeof(NSObject))]
	interface STPConnectAccountAddress
	{
		// @property (copy, nonatomic) NSString * _Nullable city;
		[NullAllowed, Export("city")]
		string City { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable country;
		[NullAllowed, Export("country")]
		string Country { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable line1;
		[NullAllowed, Export("line1")]
		string Line1 { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable line2;
		[NullAllowed, Export("line2")]
		string Line2 { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable postalCode;
		[NullAllowed, Export("postalCode")]
		string PostalCode { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable state;
		[NullAllowed, Export("state")]
		string State { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable town;
		[NullAllowed, Export("town")]
		string Town { get; set; }
	}

	// @interface STPConnectAccountParams : NSObject <STPFormEncodable>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface STPConnectAccountParams
	{
		// @property (readonly, nonatomic) NSNumber * _Nullable tosShownAndAccepted;
		[NullAllowed, Export("tosShownAndAccepted")]
		NSNumber TosShownAndAccepted { get; }

		// @property (readonly, nonatomic) STPConnectAccountBusinessType businessType;
		[Export("businessType")]
		STPConnectAccountBusinessType BusinessType { get; }

		// @property (readonly, nonatomic) STPConnectAccountIndividualParams * _Nullable individual;
		[NullAllowed, Export("individual")]
		STPConnectAccountIndividualParams Individual { get; }

		// @property (readonly, nonatomic) STPConnectAccountCompanyParams * _Nullable company;
		[NullAllowed, Export("company")]
		STPConnectAccountCompanyParams Company { get; }

		// -(instancetype _Nonnull)initWithTosShownAndAccepted:(BOOL)wasAccepted individual:(STPConnectAccountIndividualParams * _Nonnull)individual;
		[Export("initWithTosShownAndAccepted:individual:")]
		IntPtr Constructor(bool wasAccepted, STPConnectAccountIndividualParams individual);

		// -(instancetype _Nonnull)initWithTosShownAndAccepted:(BOOL)wasAccepted company:(STPConnectAccountCompanyParams * _Nonnull)company;
		[Export("initWithTosShownAndAccepted:company:")]
		IntPtr Constructor(bool wasAccepted, STPConnectAccountCompanyParams company);

		// -(instancetype _Nonnull)initWithIndividual:(STPConnectAccountIndividualParams * _Nonnull)individual;
		[Export("initWithIndividual:")]
		IntPtr Constructor(STPConnectAccountIndividualParams individual);

		// -(instancetype _Nonnull)initWithCompany:(STPConnectAccountCompanyParams * _Nonnull)company;
		[Export("initWithCompany:")]
		IntPtr Constructor(STPConnectAccountCompanyParams company);
	}

	// @interface STPConnectAccountCompanyParams : NSObject <STPFormEncodable>
	[BaseType(typeof(NSObject))]
	interface STPConnectAccountCompanyParams
	{
		// @property (nonatomic, strong) STPConnectAccountAddress * _Nonnull address;
		[Export("address", ArgumentSemantic.Strong)]
		STPConnectAccountAddress Address { get; set; }

		// @property (nonatomic) STPConnectAccountAddress * _Nullable kanaAddress;
		[NullAllowed, Export("kanaAddress", ArgumentSemantic.Assign)]
		STPConnectAccountAddress KanaAddress { get; set; }

		// @property (nonatomic) STPConnectAccountAddress * _Nullable kanjiAddress;
		[NullAllowed, Export("kanjiAddress", ArgumentSemantic.Assign)]
		STPConnectAccountAddress KanjiAddress { get; set; }

		// @property (nonatomic) NSNumber * _Nullable directorsProvided;
		[NullAllowed, Export("directorsProvided", ArgumentSemantic.Assign)]
		NSNumber DirectorsProvided { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export("name")]
		string Name { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable kanaName;
		[NullAllowed, Export("kanaName")]
		string KanaName { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable kanjiName;
		[NullAllowed, Export("kanjiName")]
		string KanjiName { get; set; }

		// @property (nonatomic) NSNumber * _Nullable ownersProvided;
		[NullAllowed, Export("ownersProvided", ArgumentSemantic.Assign)]
		NSNumber OwnersProvided { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable phone;
		[NullAllowed, Export("phone")]
		string Phone { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable taxID;
		[NullAllowed, Export("taxID")]
		string TaxID { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable taxIDRegistrar;
		[NullAllowed, Export("taxIDRegistrar")]
		string TaxIDRegistrar { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable vatID;
		[NullAllowed, Export("vatID")]
		string VatID { get; set; }
	}

	// @interface STPConnectAccountIndividualParams : NSObject <STPFormEncodable>
	[BaseType(typeof(NSObject))]
	interface STPConnectAccountIndividualParams
	{
		// @property (nonatomic) STPConnectAccountAddress * _Nullable address;
		[NullAllowed, Export("address", ArgumentSemantic.Assign)]
		STPConnectAccountAddress Address { get; set; }

		// @property (nonatomic) STPConnectAccountAddress * _Nullable kanaAddress;
		[NullAllowed, Export("kanaAddress", ArgumentSemantic.Assign)]
		STPConnectAccountAddress KanaAddress { get; set; }

		// @property (nonatomic) STPConnectAccountAddress * _Nullable kanjiAddress;
		[NullAllowed, Export("kanjiAddress", ArgumentSemantic.Assign)]
		STPConnectAccountAddress KanjiAddress { get; set; }

		// @property (copy, nonatomic) NSDateComponents * _Nullable dateOfBirth;
		[NullAllowed, Export("dateOfBirth", ArgumentSemantic.Copy)]
		NSDateComponents DateOfBirth { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable email;
		[NullAllowed, Export("email")]
		string Email { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable firstName;
		[NullAllowed, Export("firstName")]
		string FirstName { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable kanaFirstName;
		[NullAllowed, Export("kanaFirstName")]
		string KanaFirstName { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable kanjiFirstName;
		[NullAllowed, Export("kanjiFirstName")]
		string KanjiFirstName { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable gender;
		[NullAllowed, Export("gender")]
		string Gender { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable idNumber;
		[NullAllowed, Export("idNumber")]
		string IdNumber { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable lastName;
		[NullAllowed, Export("lastName")]
		string LastName { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable kanaLastName;
		[NullAllowed, Export("kanaLastName")]
		string KanaLastName { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable kanjiLastName;
		[NullAllowed, Export("kanjiLastName")]
		string KanjiLastName { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable maidenName;
		[NullAllowed, Export("maidenName")]
		string MaidenName { get; set; }

		// @property (copy, nonatomic) NSDictionary * _Nullable metadata;
		[NullAllowed, Export("metadata", ArgumentSemantic.Copy)]
		NSDictionary Metadata { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable phone;
		[NullAllowed, Export("phone")]
		string Phone { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable ssnLast4;
		[NullAllowed, Export("ssnLast4")]
		string SsnLast4 { get; set; }

		// @property (nonatomic, strong) STPConnectAccountIndividualVerification * _Nullable verification;
		[NullAllowed, Export("verification", ArgumentSemantic.Strong)]
		STPConnectAccountIndividualVerification Verification { get; set; }
	}

	// @interface STPConnectAccountIndividualVerification : NSObject <STPFormEncodable>
	[BaseType(typeof(NSObject))]
	interface STPConnectAccountIndividualVerification
	{
		// @property (nonatomic, strong) STPConnectAccountVerificationDocument * _Nullable document;
		[NullAllowed, Export("document", ArgumentSemantic.Strong)]
		STPConnectAccountVerificationDocument Document { get; set; }
	}

	// @interface STPConnectAccountVerificationDocument : NSObject <STPFormEncodable>
	[BaseType(typeof(NSObject))]
	interface STPConnectAccountVerificationDocument
	{
		// @property (copy, nonatomic) NSString * _Nullable back;
		[NullAllowed, Export("back")]
		string Back { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable front;
		[NullAllowed, Export("front")]
		string Front { get; set; }
	}

	// @interface STPDateOfBirth : NSObject <STPFormEncodable>
	[BaseType(typeof(NSObject))]
	interface STPDateOfBirth
	{
		// @property (nonatomic) NSInteger day;
		[Export("day")]
		nint Day { get; set; }

		// @property (nonatomic) NSInteger month;
		[Export("month")]
		nint Month { get; set; }

		// @property (nonatomic) NSInteger year;
		[Export("year")]
		nint Year { get; set; }
	}

	// @interface STPCustomerContext : NSObject <STPBackendAPIAdapter>
	[BaseType(typeof(NSObject))]
	interface STPCustomerContext : STPBackendAPIAdapter
	{
		// -(instancetype _Nonnull)initWithKeyProvider:(id<STPCustomerEphemeralKeyProvider> _Nonnull)keyProvider;
		[Export("initWithKeyProvider:")]
		IntPtr Constructor(STPCustomerEphemeralKeyProvider keyProvider);

		// -(instancetype _Nonnull)initWithKeyProvider:(id<STPCustomerEphemeralKeyProvider> _Nonnull)keyProvider apiClient:(STPAPIClient * _Nonnull)apiClient;
		[Export("initWithKeyProvider:apiClient:")]
		IntPtr Constructor(STPCustomerEphemeralKeyProvider keyProvider, STPAPIClient apiClient);

		// -(void)clearCache;
		[Export("clearCache")]
		void ClearCache();

		// @property (assign, nonatomic) BOOL includeApplePayPaymentMethods;
		[Export("includeApplePayPaymentMethods")]
		bool IncludeApplePayPaymentMethods { get; set; }
	}

	// @interface STPFakeAddPaymentPassViewController : UIViewController
	[BaseType(typeof(UIViewController))]
	interface STPFakeAddPaymentPassViewController
	{
		// +(BOOL)canAddPaymentPass;
		[Static]
		[Export("canAddPaymentPass")]
		bool CanAddPaymentPass { get; }

		// -(instancetype _Nullable)initWithRequestConfiguration:(PKAddPaymentPassRequestConfiguration * _Nonnull)configuration delegate:(id<PKAddPaymentPassViewControllerDelegate> _Nullable)delegate __attribute__((objc_designated_initializer));
		[Export("initWithRequestConfiguration:delegate:")]
		[DesignatedInitializer]
		IntPtr Constructor(PKAddPaymentPassRequestConfiguration configuration, [NullAllowed] PKAddPaymentPassViewControllerDelegate @delegate);

		[Wrap("WeakDelegate")]
		[NullAllowed]
		PKAddPaymentPassViewControllerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<PKAddPaymentPassViewControllerDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }
	}

	// @interface STPImageLibrary : NSObject
	[BaseType(typeof(NSObject))]
	interface STPImageLibrary
	{
		// +(UIImage * _Nonnull)applePayCardImage;
		[Static]
		[Export("applePayCardImage")]
		UIImage ApplePayCardImage { get; }

		// +(UIImage * _Nonnull)amexCardImage;
		[Static]
		[Export("amexCardImage")]
		UIImage AmexCardImage { get; }

		// +(UIImage * _Nonnull)dinersClubCardImage;
		[Static]
		[Export("dinersClubCardImage")]
		UIImage DinersClubCardImage { get; }

		// +(UIImage * _Nonnull)discoverCardImage;
		[Static]
		[Export("discoverCardImage")]
		UIImage DiscoverCardImage { get; }

		// +(UIImage * _Nonnull)jcbCardImage;
		[Static]
		[Export("jcbCardImage")]
		UIImage JcbCardImage { get; }

		// +(UIImage * _Nonnull)masterCardCardImage;
		[Static]
		[Export("masterCardCardImage")]
		UIImage MasterCardCardImage { get; }

		// +(UIImage * _Nonnull)unionPayCardImage;
		[Static]
		[Export("unionPayCardImage")]
		UIImage UnionPayCardImage { get; }

		// +(UIImage * _Nonnull)visaCardImage;
		[Static]
		[Export("visaCardImage")]
		UIImage VisaCardImage { get; }

		// +(UIImage * _Nonnull)unknownCardCardImage;
		[Static]
		[Export("unknownCardCardImage")]
		UIImage UnknownCardCardImage { get; }

		// +(UIImage * _Nonnull)brandImageForCardBrand:(STPCardBrand)brand;
		[Static]
		[Export("brandImageForCardBrand:")]
		UIImage BrandImageForCardBrand(STPCardBrand brand);

		// +(UIImage * _Nonnull)brandImageForFPXBankBrand:(STPFPXBankBrand)brand;
		[Static]
		[Export("brandImageForFPXBankBrand:")]
		UIImage BrandImageForFPXBankBrand(STPFPXBankBrand brand);

		// +(UIImage * _Nonnull)fpxLogo;
		[Static]
		[Export("fpxLogo")]
		UIImage FpxLogo { get; }

		// +(UIImage * _Nonnull)largeFpxLogo;
		[Static]
		[Export("largeFpxLogo")]
		UIImage LargeFpxLogo { get; }

		// +(UIImage * _Nonnull)templatedBrandImageForCardBrand:(STPCardBrand)brand;
		[Static]
		[Export("templatedBrandImageForCardBrand:")]
		UIImage TemplatedBrandImageForCardBrand(STPCardBrand brand);

		// +(UIImage * _Nonnull)cvcImageForCardBrand:(STPCardBrand)brand;
		[Static]
		[Export("cvcImageForCardBrand:")]
		UIImage CvcImageForCardBrand(STPCardBrand brand);

		// +(UIImage * _Nonnull)errorImageForCardBrand:(STPCardBrand)brand;
		[Static]
		[Export("errorImageForCardBrand:")]
		UIImage ErrorImageForCardBrand(STPCardBrand brand);
	}

	// @interface STPIntentAction : NSObject <STPAPIResponseDecodable>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface STPIntentAction
	{
		// @property (readonly, nonatomic) STPIntentActionType type;
		[Export("type")]
		STPIntentActionType Type { get; }

		// @property (readonly, nonatomic, strong) STPIntentActionRedirectToURL * _Nullable redirectToURL;
		[NullAllowed, Export("redirectToURL", ArgumentSemantic.Strong)]
		STPIntentActionRedirectToURL RedirectToURL { get; }

		// @property (readonly, nonatomic) STPIntentActionAlipayHandleRedirect * _Nullable alipayHandleRedirect;
		[NullAllowed, Export("alipayHandleRedirect")]
		STPIntentActionAlipayHandleRedirect AlipayHandleRedirect { get; }

		// @property (readonly, nonatomic, strong) STPIntentActionRedirectToURL * _Nullable authorizeWithURL __attribute__((deprecated("Use `redirectToURL` instead", "redirectToURL")));
		[NullAllowed, Export("authorizeWithURL", ArgumentSemantic.Strong)]
		STPIntentActionRedirectToURL AuthorizeWithURL { get; }
	}

	// @interface STPIntentActionRedirectToURL : NSObject <STPAPIResponseDecodable>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface STPIntentActionRedirectToURL
	{
		// @property (readonly, nonatomic) NSURL * _Nonnull url;
		[Export("url")]
		NSUrl Url { get; }

		// @property (readonly, nonatomic) NSURL * _Nullable returnURL;
		[NullAllowed, Export("returnURL")]
		NSUrl ReturnURL { get; }
	}

	// @interface STPIntentActionAlipayHandleRedirect : NSObject <STPAPIResponseDecodable>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface STPIntentActionAlipayHandleRedirect
	{
		// @property (readonly, nonatomic) NSURL * _Nullable nativeURL;
		[NullAllowed, Export("nativeURL")]
		NSUrl NativeURL { get; }

		// @property (readonly, nonatomic) NSURL * _Nonnull returnURL;
		[Export("returnURL")]
		NSUrl ReturnURL { get; }

		// @property (readonly, nonatomic) NSURL * _Nonnull url;
		[Export("url")]
		NSUrl Url { get; }
	}

	// @interface STPKlarnaLineItem : NSObject
	[BaseType(typeof(NSObject))]
	interface STPKlarnaLineItem
	{
		// @property (nonatomic) STPKlarnaLineItemType itemType;
		[Export("itemType", ArgumentSemantic.Assign)]
		STPKlarnaLineItemType ItemType { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull itemDescription;
		[Export("itemDescription")]
		string ItemDescription { get; set; }

		// @property (copy, nonatomic) NSNumber * _Nonnull quantity;
		[Export("quantity", ArgumentSemantic.Copy)]
		NSNumber Quantity { get; set; }

		// @property (copy, nonatomic) NSNumber * _Nonnull totalAmount;
		[Export("totalAmount", ArgumentSemantic.Copy)]
		NSNumber TotalAmount { get; set; }

		// -(instancetype _Nonnull)initWithItemType:(STPKlarnaLineItemType)itemType itemDescription:(NSString * _Nonnull)itemDescription quantity:(NSNumber * _Nonnull)quantity totalAmount:(NSNumber * _Nonnull)totalAmount;
		[Export("initWithItemType:itemDescription:quantity:totalAmount:")]
		IntPtr Constructor(STPKlarnaLineItemType itemType, string itemDescription, NSNumber quantity, NSNumber totalAmount);
	}

	// @interface STPMandateCustomerAcceptanceParams : NSObject <STPFormEncodable>
	[BaseType(typeof(NSObject))]
	interface STPMandateCustomerAcceptanceParams
	{
		// @property (nonatomic) STPMandateCustomerAcceptanceType type;
		[Export("type", ArgumentSemantic.Assign)]
		STPMandateCustomerAcceptanceType Type { get; set; }

		// @property (nonatomic) STPMandateOnlineParams * _Nullable onlineParams;
		[NullAllowed, Export("onlineParams", ArgumentSemantic.Assign)]
		STPMandateOnlineParams OnlineParams { get; set; }
	}

	// @interface STPMandateDataParams : NSObject <STPFormEncodable>
	[BaseType(typeof(NSObject))]
	interface STPMandateDataParams
	{
		// @property (nonatomic) STPMandateCustomerAcceptanceParams * _Nonnull customerAcceptance;
		[Export("customerAcceptance", ArgumentSemantic.Assign)]
		STPMandateCustomerAcceptanceParams CustomerAcceptance { get; set; }
	}

	// @interface STPMandateOnlineParams : NSObject <STPFormEncodable>
	[BaseType(typeof(NSObject))]
	interface STPMandateOnlineParams
	{
		// @property (copy, nonatomic) NSString * _Nonnull ipAddress;
		[Export("ipAddress")]
		string IpAddress { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull userAgent;
		[Export("userAgent")]
		string UserAgent { get; set; }
	}

	// @interface STPPaymentActivityIndicatorView : UIView
	[BaseType(typeof(UIView))]
	interface STPPaymentActivityIndicatorView
	{
		// -(void)setAnimating:(BOOL)animating animated:(BOOL)animated;
		[Export("setAnimating:animated:")]
		void SetAnimating(bool animating, bool animated);

		// @property (nonatomic) BOOL animating;
		[Export("animating")]
		bool Animating { get; set; }

		// @property (nonatomic) BOOL hidesWhenStopped;
		[Export("hidesWhenStopped")]
		bool HidesWhenStopped { get; set; }
	}

	// @interface STPPaymentMethodCard : NSObject <STPAPIResponseDecodable>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface STPPaymentMethodCard
	{
		// @property (readonly, nonatomic) STPCardBrand brand;
		[Export("brand")]
		STPCardBrand Brand { get; }

		// @property (readonly, nonatomic) STPPaymentMethodCardChecks * _Nullable checks;
		[NullAllowed, Export("checks")]
		STPPaymentMethodCardChecks Checks { get; }

		// @property (readonly, nonatomic) NSString * _Nullable country;
		[NullAllowed, Export("country")]
		string Country { get; }

		// @property (readonly, nonatomic) NSInteger expMonth;
		[Export("expMonth")]
		nint ExpMonth { get; }

		// @property (readonly, nonatomic) NSInteger expYear;
		[Export("expYear")]
		nint ExpYear { get; }

		// @property (readonly, nonatomic) NSString * _Nullable funding;
		[NullAllowed, Export("funding")]
		string Funding { get; }

		// @property (readonly, nonatomic) NSString * _Nullable last4;
		[NullAllowed, Export("last4")]
		string Last4 { get; }

		// @property (readonly, nonatomic) NSString * _Nullable fingerprint;
		[NullAllowed, Export("fingerprint")]
		string Fingerprint { get; }

		// @property (readonly, nonatomic) STPPaymentMethodCardNetworks * _Nullable networks;
		[NullAllowed, Export("networks")]
		STPPaymentMethodCardNetworks Networks { get; }

		// @property (readonly, nonatomic) STPPaymentMethodThreeDSecureUsage * _Nullable threeDSecureUsage;
		[NullAllowed, Export("threeDSecureUsage")]
		STPPaymentMethodThreeDSecureUsage ThreeDSecureUsage { get; }

		// @property (readonly, nonatomic) STPPaymentMethodCardWallet * _Nullable wallet;
		[NullAllowed, Export("wallet")]
		STPPaymentMethodCardWallet Wallet { get; }

		// +(NSString * _Nonnull)stringFromBrand:(STPCardBrand)brand;
		[Static]
		[Export("stringFromBrand:")]
		string StringFromBrand(STPCardBrand brand);
	}

	// @interface STPPaymentCardTextField : UIControl <UIKeyInput>
	[BaseType(typeof(UIControl))]
	interface STPPaymentCardTextField : IUIKeyInput
	{
		[Wrap("WeakDelegate")]
		[NullAllowed]
		STPPaymentCardTextFieldDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<STPPaymentCardTextFieldDelegate> _Nullable delegate __attribute__((iboutlet));
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (copy, nonatomic, null_resettable) UI_APPEARANCE_SELECTOR UIFont * font __attribute__((annotate("ui_appearance_selector")));
		[NullAllowed, Export("font", ArgumentSemantic.Copy)]
		UIFont Font { get; set; }

		// @property (copy, nonatomic, null_resettable) UI_APPEARANCE_SELECTOR UIColor * textColor __attribute__((annotate("ui_appearance_selector")));
		[NullAllowed, Export("textColor", ArgumentSemantic.Copy)]
		UIColor TextColor { get; set; }

		// @property (copy, nonatomic, null_resettable) UI_APPEARANCE_SELECTOR UIColor * textErrorColor __attribute__((annotate("ui_appearance_selector")));
		[NullAllowed, Export("textErrorColor", ArgumentSemantic.Copy)]
		UIColor TextErrorColor { get; set; }

		// @property (copy, nonatomic, null_resettable) UI_APPEARANCE_SELECTOR UIColor * placeholderColor __attribute__((annotate("ui_appearance_selector")));
		[NullAllowed, Export("placeholderColor", ArgumentSemantic.Copy)]
		UIColor PlaceholderColor { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable numberPlaceholder;
		[NullAllowed, Export("numberPlaceholder")]
		string NumberPlaceholder { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable expirationPlaceholder;
		[NullAllowed, Export("expirationPlaceholder")]
		string ExpirationPlaceholder { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable cvcPlaceholder;
		[NullAllowed, Export("cvcPlaceholder")]
		string CvcPlaceholder { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable postalCodePlaceholder;
		[NullAllowed, Export("postalCodePlaceholder")]
		string PostalCodePlaceholder { get; set; }

		// @property (copy, nonatomic, null_resettable) UI_APPEARANCE_SELECTOR UIColor * cursorColor __attribute__((annotate("ui_appearance_selector")));
		[NullAllowed, Export("cursorColor", ArgumentSemantic.Copy)]
		UIColor CursorColor { get; set; }

		// @property (copy, nonatomic) UI_APPEARANCE_SELECTOR UIColor * borderColor __attribute__((annotate("ui_appearance_selector")));
		[Export("borderColor", ArgumentSemantic.Copy)]
		UIColor BorderColor { get; set; }

		// @property (assign, nonatomic) CGFloat borderWidth __attribute__((annotate("ui_appearance_selector")));
		[Export("borderWidth")]
		nfloat BorderWidth { get; set; }

		// @property (assign, nonatomic) CGFloat cornerRadius __attribute__((annotate("ui_appearance_selector")));
		[Export("cornerRadius")]
		nfloat CornerRadius { get; set; }

		// @property (assign, nonatomic) UIKeyboardAppearance keyboardAppearance __attribute__((annotate("ui_appearance_selector")));
		[Export("keyboardAppearance", ArgumentSemantic.Assign)]
		UIKeyboardAppearance KeyboardAppearance { get; set; }

		// @property (nonatomic, strong) UIView * _Nullable inputView;
		[NullAllowed, Export("inputView", ArgumentSemantic.Strong)]
		UIView InputView { get; set; }

		// @property (nonatomic, strong) UIView * _Nullable inputAccessoryView;
		[NullAllowed, Export("inputAccessoryView", ArgumentSemantic.Strong)]
		UIView InputAccessoryView { get; set; }

		// @property (readonly, nonatomic) UIImage * _Nullable brandImage;
		[NullAllowed, Export("brandImage")]
		UIImage BrandImage { get; }

		// @property (readonly, nonatomic) BOOL isValid;
		[Export("isValid")]
		bool IsValid { get; }

		// @property (getter = isEnabled, nonatomic) BOOL enabled;
		[Export("enabled")]
		bool Enabled { [Bind("isEnabled")] get; set; }

		// @property (readonly, nonatomic) NSString * _Nullable cardNumber;
		[NullAllowed, Export("cardNumber")]
		string CardNumber { get; }

		// @property (readonly, nonatomic) NSUInteger expirationMonth;
		[Export("expirationMonth")]
		nuint ExpirationMonth { get; }

		// @property (readonly, nonatomic) NSString * _Nullable formattedExpirationMonth;
		[NullAllowed, Export("formattedExpirationMonth")]
		string FormattedExpirationMonth { get; }

		// @property (readonly, nonatomic) NSUInteger expirationYear;
		[Export("expirationYear")]
		nuint ExpirationYear { get; }

		// @property (readonly, nonatomic) NSString * _Nullable formattedExpirationYear;
		[NullAllowed, Export("formattedExpirationYear")]
		string FormattedExpirationYear { get; }

		// @property (readonly, nonatomic) NSString * _Nullable cvc;
		[NullAllowed, Export("cvc")]
		string Cvc { get; }

		// @property (readonly, nonatomic) NSString * _Nullable postalCode;
		[NullAllowed, Export("postalCode")]
		string PostalCode { get; }

		// @property (assign, readwrite, nonatomic) BOOL postalCodeEntryEnabled;
		[Export("postalCodeEntryEnabled")]
		bool PostalCodeEntryEnabled { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable countryCode;
		[NullAllowed, Export("countryCode")]
		string CountryCode { get; set; }

		// @property (readwrite, copy, nonatomic) STPPaymentMethodCardParams * _Nonnull cardParams;
		[Export("cardParams", ArgumentSemantic.Copy)]
		STPPaymentMethodCardParams CardParams { get; set; }

		// -(BOOL)becomeFirstResponder;
		[Export("becomeFirstResponder")]
		bool BecomeFirstResponder { get; }

		// -(BOOL)resignFirstResponder;
		[Export("resignFirstResponder")]
		bool ResignFirstResponder { get; }

		// -(void)clear;
		[Export("clear")]
		void Clear();

		// +(UIImage * _Nullable)cvcImageForCardBrand:(STPCardBrand)cardBrand;
		[Static]
		[Export("cvcImageForCardBrand:")]
		[return: NullAllowed]
		UIImage CvcImageForCardBrand(STPCardBrand cardBrand);

		// +(UIImage * _Nullable)brandImageForCardBrand:(STPCardBrand)cardBrand;
		[Static]
		[Export("brandImageForCardBrand:")]
		[return: NullAllowed]
		UIImage BrandImageForCardBrand(STPCardBrand cardBrand);

		// +(UIImage * _Nullable)errorImageForCardBrand:(STPCardBrand)cardBrand;
		[Static]
		[Export("errorImageForCardBrand:")]
		[return: NullAllowed]
		UIImage ErrorImageForCardBrand(STPCardBrand cardBrand);

		// -(CGRect)brandImageRectForBounds:(CGRect)bounds;
		[Export("brandImageRectForBounds:")]
		CGRect BrandImageRectForBounds(CGRect bounds);

		// -(CGRect)fieldsRectForBounds:(CGRect)bounds;
		[Export("fieldsRectForBounds:")]
		CGRect FieldsRectForBounds(CGRect bounds);
	}

	// @protocol STPPaymentCardTextFieldDelegate <NSObject>
	[Protocol, Model(AutoGeneratedName = true)]
	[BaseType(typeof(NSObject))]
	interface STPPaymentCardTextFieldDelegate
	{
		// @optional -(void)paymentCardTextFieldDidChange:(STPPaymentCardTextField * _Nonnull)textField;
		[Export("paymentCardTextFieldDidChange:")]
		void PaymentCardTextFieldDidChange(STPPaymentCardTextField textField);

		// @optional -(void)paymentCardTextFieldDidBeginEditing:(STPPaymentCardTextField * _Nonnull)textField;
		[Export("paymentCardTextFieldDidBeginEditing:")]
		void PaymentCardTextFieldDidBeginEditing(STPPaymentCardTextField textField);

		// @optional -(void)paymentCardTextFieldWillEndEditingForReturn:(STPPaymentCardTextField * _Nonnull)textField;
		[Export("paymentCardTextFieldWillEndEditingForReturn:")]
		void PaymentCardTextFieldWillEndEditingForReturn(STPPaymentCardTextField textField);

		// @optional -(void)paymentCardTextFieldDidEndEditing:(STPPaymentCardTextField * _Nonnull)textField;
		[Export("paymentCardTextFieldDidEndEditing:")]
		void PaymentCardTextFieldDidEndEditing(STPPaymentCardTextField textField);

		// @optional -(void)paymentCardTextFieldDidBeginEditingNumber:(STPPaymentCardTextField * _Nonnull)textField;
		[Export("paymentCardTextFieldDidBeginEditingNumber:")]
		void PaymentCardTextFieldDidBeginEditingNumber(STPPaymentCardTextField textField);

		// @optional -(void)paymentCardTextFieldDidEndEditingNumber:(STPPaymentCardTextField * _Nonnull)textField;
		[Export("paymentCardTextFieldDidEndEditingNumber:")]
		void PaymentCardTextFieldDidEndEditingNumber(STPPaymentCardTextField textField);

		// @optional -(void)paymentCardTextFieldDidBeginEditingCVC:(STPPaymentCardTextField * _Nonnull)textField;
		[Export("paymentCardTextFieldDidBeginEditingCVC:")]
		void PaymentCardTextFieldDidBeginEditingCVC(STPPaymentCardTextField textField);

		// @optional -(void)paymentCardTextFieldDidEndEditingCVC:(STPPaymentCardTextField * _Nonnull)textField;
		[Export("paymentCardTextFieldDidEndEditingCVC:")]
		void PaymentCardTextFieldDidEndEditingCVC(STPPaymentCardTextField textField);

		// @optional -(void)paymentCardTextFieldDidBeginEditingExpiration:(STPPaymentCardTextField * _Nonnull)textField;
		[Export("paymentCardTextFieldDidBeginEditingExpiration:")]
		void PaymentCardTextFieldDidBeginEditingExpiration(STPPaymentCardTextField textField);

		// @optional -(void)paymentCardTextFieldDidEndEditingExpiration:(STPPaymentCardTextField * _Nonnull)textField;
		[Export("paymentCardTextFieldDidEndEditingExpiration:")]
		void PaymentCardTextFieldDidEndEditingExpiration(STPPaymentCardTextField textField);

		// @optional -(void)paymentCardTextFieldDidBeginEditingPostalCode:(STPPaymentCardTextField * _Nonnull)textField;
		[Export("paymentCardTextFieldDidBeginEditingPostalCode:")]
		void PaymentCardTextFieldDidBeginEditingPostalCode(STPPaymentCardTextField textField);

		// @optional -(void)paymentCardTextFieldDidEndEditingPostalCode:(STPPaymentCardTextField * _Nonnull)textField;
		[Export("paymentCardTextFieldDidEndEditingPostalCode:")]
		void PaymentCardTextFieldDidEndEditingPostalCode(STPPaymentCardTextField textField);
	}

	// @interface STPPaymentResult : NSObject
	[BaseType(typeof(NSObject))]
	interface STPPaymentResult
	{
		// @property (readonly, nonatomic) STPPaymentMethod * _Nullable paymentMethod;
		[NullAllowed, Export("paymentMethod")]
		STPPaymentMethod PaymentMethod { get; }

		// @property (readonly, nonatomic) STPPaymentMethodParams * _Nullable paymentMethodParams;
		[NullAllowed, Export("paymentMethodParams")]
		STPPaymentMethodParams PaymentMethodParams { get; }

		// @property (readonly, nonatomic) id<STPPaymentOption> _Nonnull paymentOption;
		[Export("paymentOption")]
		STPPaymentOption PaymentOption { get; }

		// -(instancetype _Nonnull)initWithPaymentOption:(id<STPPaymentOption> _Nonnull)paymentOption;
		[Export("initWithPaymentOption:")]
		IntPtr Constructor(STPPaymentOption paymentOption);
	}

	// @interface STPPaymentContext : NSObject <STPAuthenticationContext>
	[BaseType(typeof(NSObject))]
	interface STPPaymentContext : STPAuthenticationContext
	{
		// -(instancetype _Nonnull)initWithCustomerContext:(STPCustomerContext * _Nonnull)customerContext;
		[Export("initWithCustomerContext:")]
		IntPtr Constructor(STPCustomerContext customerContext);

		// -(instancetype _Nonnull)initWithCustomerContext:(STPCustomerContext * _Nonnull)customerContext configuration:(STPPaymentConfiguration * _Nonnull)configuration theme:(STPTheme * _Nonnull)theme;
		[Export("initWithCustomerContext:configuration:theme:")]
		IntPtr Constructor(STPCustomerContext customerContext, STPPaymentConfiguration configuration, STPTheme theme);

		// -(instancetype _Nonnull)initWithAPIAdapter:(id<STPBackendAPIAdapter> _Nonnull)apiAdapter;
		[Export("initWithAPIAdapter:")]
		IntPtr Constructor(STPBackendAPIAdapter apiAdapter);

		// -(instancetype _Nonnull)initWithAPIAdapter:(id<STPBackendAPIAdapter> _Nonnull)apiAdapter configuration:(STPPaymentConfiguration * _Nonnull)configuration theme:(STPTheme * _Nonnull)theme;
		[Export("initWithAPIAdapter:configuration:theme:")]
		IntPtr Constructor(STPBackendAPIAdapter apiAdapter, STPPaymentConfiguration configuration, STPTheme theme);

		// @property (readonly, nonatomic) id<STPBackendAPIAdapter> _Nonnull apiAdapter;
		[Export("apiAdapter")]
		STPBackendAPIAdapter ApiAdapter { get; }

		// @property (readonly, nonatomic) STPPaymentConfiguration * _Nonnull configuration;
		[Export("configuration")]
		STPPaymentConfiguration Configuration { get; }

		// @property (readonly, nonatomic) STPTheme * _Nonnull theme;
		[Export("theme")]
		STPTheme Theme { get; }

		// @property (nonatomic, strong) STPUserInformation * _Nullable prefilledInformation;
		[NullAllowed, Export("prefilledInformation", ArgumentSemantic.Strong)]
		STPUserInformation PrefilledInformation { get; set; }

		// @property (nonatomic, weak) UIViewController * _Nullable hostViewController;
		[NullAllowed, Export("hostViewController", ArgumentSemantic.Weak)]
		UIViewController HostViewController { get; set; }

		[Wrap("WeakDelegate")]
		[NullAllowed]
		STPPaymentContextDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<STPPaymentContextDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic) BOOL loading;
		[Export("loading")]
		bool Loading { get; }

		// @property (copy, nonatomic) NSString * _Nullable defaultPaymentMethod;
		[NullAllowed, Export("defaultPaymentMethod")]
		string DefaultPaymentMethod { get; set; }

		// @property (readonly, nonatomic) id<STPPaymentOption> _Nullable selectedPaymentOption;
		[NullAllowed, Export("selectedPaymentOption")]
		STPPaymentOption SelectedPaymentOption { get; }

		// @property (readonly, nonatomic) NSArray<id<STPPaymentOption>> * _Nullable paymentOptions;
		[NullAllowed, Export("paymentOptions")]
		STPPaymentOption[] PaymentOptions { get; }

		// @property (readonly, nonatomic) PKShippingMethod * _Nullable selectedShippingMethod;
		[NullAllowed, Export("selectedShippingMethod")]
		PKShippingMethod SelectedShippingMethod { get; }

		// @property (readonly, nonatomic) NSArray<PKShippingMethod *> * _Nullable shippingMethods;
		[NullAllowed, Export("shippingMethods")]
		PKShippingMethod[] ShippingMethods { get; }

		// @property (readonly, nonatomic) STPAddress * _Nullable shippingAddress;
		[NullAllowed, Export("shippingAddress")]
		STPAddress ShippingAddress { get; }

		// @property (nonatomic) NSInteger paymentAmount;
		[Export("paymentAmount")]
		nint PaymentAmount { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull paymentCurrency;
		[Export("paymentCurrency")]
		string PaymentCurrency { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull paymentCountry;
		[Export("paymentCountry")]
		string PaymentCountry { get; set; }

		// @property (copy, nonatomic) NSArray<PKPaymentSummaryItem *> * _Nonnull paymentSummaryItems;
		[Export("paymentSummaryItems", ArgumentSemantic.Copy)]
		PKPaymentSummaryItem[] PaymentSummaryItems { get; set; }

		// @property (assign, nonatomic) UIModalPresentationStyle modalPresentationStyle;
		[Export("modalPresentationStyle", ArgumentSemantic.Assign)]
		UIModalPresentationStyle ModalPresentationStyle { get; set; }

		// @property (assign, nonatomic) UINavigationItemLargeTitleDisplayMode largeTitleDisplayMode __attribute__((availability(ios, introduced=11.0)));
		[iOS(11, 0)]
		[Export("largeTitleDisplayMode", ArgumentSemantic.Assign)]
		UINavigationItemLargeTitleDisplayMode LargeTitleDisplayMode { get; set; }

		// @property (nonatomic, strong) UIView * _Nonnull paymentOptionsViewControllerFooterView;
		[Export("paymentOptionsViewControllerFooterView", ArgumentSemantic.Strong)]
		UIView PaymentOptionsViewControllerFooterView { get; set; }

		// @property (nonatomic, strong) UIView * _Nonnull addCardViewControllerFooterView;
		[Export("addCardViewControllerFooterView", ArgumentSemantic.Strong)]
		UIView AddCardViewControllerFooterView { get; set; }

		// @property (nonatomic, strong) STPAPIClient * _Nonnull apiClient;
		[Export("apiClient", ArgumentSemantic.Strong)]
		STPAPIClient ApiClient { get; set; }

		// -(void)retryLoading;
		[Export("retryLoading")]
		void RetryLoading();

		// -(void)presentPaymentOptionsViewController;
		[Export("presentPaymentOptionsViewController")]
		void PresentPaymentOptionsViewController();

		// -(void)pushPaymentOptionsViewController;
		[Export("pushPaymentOptionsViewController")]
		void PushPaymentOptionsViewController();

		// -(void)presentShippingViewController;
		[Export("presentShippingViewController")]
		void PresentShippingViewController();

		// -(void)pushShippingViewController;
		[Export("pushShippingViewController")]
		void PushShippingViewController();

		// -(void)requestPayment;
		[Export("requestPayment")]
		void RequestPayment();
	}

	// @protocol STPPaymentContextDelegate <NSObject>
	[Protocol, Model(AutoGeneratedName = true)]
	[BaseType(typeof(NSObject))]
	interface STPPaymentContextDelegate
	{
		// @required -(void)paymentContext:(STPPaymentContext * _Nonnull)paymentContext didFailToLoadWithError:(NSError * _Nonnull)error;
		[Abstract]
		[Export("paymentContext:didFailToLoadWithError:")]
		void PaymentContext(STPPaymentContext paymentContext, NSError error);

		// @required -(void)paymentContextDidChange:(STPPaymentContext * _Nonnull)paymentContext;
		[Abstract]
		[Export("paymentContextDidChange:")]
		void PaymentContextDidChange(STPPaymentContext paymentContext);

		// @required -(void)paymentContext:(STPPaymentContext * _Nonnull)paymentContext didCreatePaymentResult:(STPPaymentResult * _Nonnull)paymentResult completion:(STPPaymentStatusBlock _Nonnull)completion;
		[Abstract]
		[Export("paymentContext:didCreatePaymentResult:completion:")]
		void PaymentContext(STPPaymentContext paymentContext, STPPaymentResult paymentResult, STPPaymentStatusBlock completion);

		// @required -(void)paymentContext:(STPPaymentContext * _Nonnull)paymentContext didFinishWithStatus:(STPPaymentStatus)status error:(NSError * _Nullable)error;
		[Abstract]
		[Export("paymentContext:didFinishWithStatus:error:")]
		void PaymentContext(STPPaymentContext paymentContext, STPPaymentStatus status, [NullAllowed] NSError error);

		// @optional -(void)paymentContext:(STPPaymentContext * _Nonnull)paymentContext didUpdateShippingAddress:(STPAddress * _Nonnull)address completion:(STPShippingMethodsCompletionBlock _Nonnull)completion;
		[Export("paymentContext:didUpdateShippingAddress:completion:")]
		void PaymentContext(STPPaymentContext paymentContext, STPAddress address, STPShippingMethodsCompletionBlock completion);
	}

	// typedef void (^STPPaymentHandlerActionPaymentIntentCompletionBlock)(STPPaymentHandlerActionStatus, STPPaymentIntent * _Nullable, NSError * _Nullable);
	delegate void STPPaymentHandlerActionPaymentIntentCompletionBlock(STPPaymentHandlerActionStatus arg0, [NullAllowed] STPPaymentIntent arg1, [NullAllowed] NSError arg2);

	// typedef void (^STPPaymentHandlerActionSetupIntentCompletionBlock)(STPPaymentHandlerActionStatus, STPSetupIntent * _Nullable, NSError * _Nullable);
	delegate void STPPaymentHandlerActionSetupIntentCompletionBlock(STPPaymentHandlerActionStatus arg0, [NullAllowed] STPSetupIntent arg1, [NullAllowed] NSError arg2);

	// @interface STPPaymentHandler : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface STPPaymentHandler
	{
		// +(instancetype _Nonnull)sharedHandler;
		[Static]
		[Export("sharedHandler")]
		STPPaymentHandler SharedHandler();

		// @property (nonatomic) STPAPIClient * _Nonnull apiClient;
		[Export("apiClient", ArgumentSemantic.Assign)]
		STPAPIClient ApiClient { get; set; }

		// @property (nonatomic) STPThreeDSCustomizationSettings * _Nonnull threeDSCustomizationSettings;
		[Export("threeDSCustomizationSettings", ArgumentSemantic.Assign)]
		STPThreeDSCustomizationSettings ThreeDSCustomizationSettings { get; set; }

		// -(void)confirmPayment:(STPPaymentIntentParams * _Nonnull)paymentParams withAuthenticationContext:(id<STPAuthenticationContext> _Nonnull)authenticationContext completion:(STPPaymentHandlerActionPaymentIntentCompletionBlock _Nonnull)completion __attribute__((swift_name("confirmPayment(withParams:authenticationContext:completion:)")));
		[Export("confirmPayment:withAuthenticationContext:completion:")]
		void ConfirmPayment(STPPaymentIntentParams paymentParams, STPAuthenticationContext authenticationContext, STPPaymentHandlerActionPaymentIntentCompletionBlock completion);

		// -(void)handleNextActionForPayment:(NSString * _Nonnull)paymentIntentClientSecret withAuthenticationContext:(id<STPAuthenticationContext> _Nonnull)authenticationContext returnURL:(NSString * _Nullable)returnURL completion:(STPPaymentHandlerActionPaymentIntentCompletionBlock _Nonnull)completion __attribute__((swift_name("handleNextAction(forPayment:authenticationContext:returnURL:completion:)")));
		[Export("handleNextActionForPayment:withAuthenticationContext:returnURL:completion:")]
		void HandleNextActionForPayment(string paymentIntentClientSecret, STPAuthenticationContext authenticationContext, [NullAllowed] string returnURL, STPPaymentHandlerActionPaymentIntentCompletionBlock completion);

		// -(void)confirmSetupIntent:(STPSetupIntentConfirmParams * _Nonnull)setupIntentConfirmParams withAuthenticationContext:(id<STPAuthenticationContext> _Nonnull)authenticationContext completion:(STPPaymentHandlerActionSetupIntentCompletionBlock _Nonnull)completion __attribute__((swift_name("confirmSetupIntent(withParams:authenticationContext:completion:)")));
		[Export("confirmSetupIntent:withAuthenticationContext:completion:")]
		void ConfirmSetupIntent(STPSetupIntentConfirmParams setupIntentConfirmParams, STPAuthenticationContext authenticationContext, STPPaymentHandlerActionSetupIntentCompletionBlock completion);

		// -(void)handleNextActionForSetupIntent:(NSString * _Nonnull)setupIntentClientSecret withAuthenticationContext:(id<STPAuthenticationContext> _Nonnull)authenticationContext returnURL:(NSString * _Nullable)returnURL completion:(STPPaymentHandlerActionSetupIntentCompletionBlock _Nonnull)completion __attribute__((swift_name("handleNextAction(forSetupIntent:authenticationContext:returnURL:completion:)")));
		[Export("handleNextActionForSetupIntent:withAuthenticationContext:returnURL:completion:")]
		void HandleNextActionForSetupIntent(string setupIntentClientSecret, STPAuthenticationContext authenticationContext, [NullAllowed] string returnURL, STPPaymentHandlerActionSetupIntentCompletionBlock completion);
	}

	// @interface STPPaymentIntent : NSObject <STPAPIResponseDecodable>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface STPPaymentIntent
	{
		// @property (readonly, nonatomic) NSString * _Nonnull stripeId;
		[Export("stripeId")]
		string StripeId { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull clientSecret;
		[Export("clientSecret")]
		string ClientSecret { get; }

		// @property (readonly, nonatomic) NSNumber * _Nonnull amount;
		[Export("amount")]
		NSNumber Amount { get; }

		// @property (readonly, nonatomic) NSDate * _Nullable canceledAt;
		[NullAllowed, Export("canceledAt")]
		NSDate CanceledAt { get; }

		// @property (readonly, nonatomic) STPPaymentIntentCaptureMethod captureMethod;
		[Export("captureMethod")]
		STPPaymentIntentCaptureMethod CaptureMethod { get; }

		// @property (readonly, nonatomic) STPPaymentIntentConfirmationMethod confirmationMethod;
		[Export("confirmationMethod")]
		STPPaymentIntentConfirmationMethod ConfirmationMethod { get; }

		// @property (readonly, nonatomic) NSDate * _Nullable created;
		[NullAllowed, Export("created")]
		NSDate Created { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull currency;
		[Export("currency")]
		string Currency { get; }

		// @property (readonly, nonatomic) NSString * _Nullable stripeDescription;
		[NullAllowed, Export("stripeDescription")]
		string StripeDescription { get; }

		// @property (readonly, nonatomic) BOOL livemode;
		[Export("livemode")]
		bool Livemode { get; }

		// @property (readonly, nonatomic) STPIntentAction * _Nullable nextAction;
		[NullAllowed, Export("nextAction")]
		STPIntentAction NextAction { get; }

		// @property (readonly, nonatomic) NSString * _Nullable receiptEmail;
		[NullAllowed, Export("receiptEmail")]
		string ReceiptEmail { get; }

		// @property (readonly, nonatomic) NSString * _Nullable sourceId;
		[NullAllowed, Export("sourceId")]
		string SourceId { get; }

		// @property (readonly, nonatomic) NSString * _Nullable paymentMethodId;
		[NullAllowed, Export("paymentMethodId")]
		string PaymentMethodId { get; }

		// @property (readonly, nonatomic) STPPaymentIntentStatus status;
		[Export("status")]
		STPPaymentIntentStatus Status { get; }

		// @property (readonly, nonatomic) NSArray<NSNumber *> * _Nullable paymentMethodTypes;
		[NullAllowed, Export("paymentMethodTypes")]
		NSNumber[] PaymentMethodTypes { get; }

		// @property (readonly, nonatomic) STPPaymentIntentSetupFutureUsage setupFutureUsage;
		[Export("setupFutureUsage")]
		STPPaymentIntentSetupFutureUsage SetupFutureUsage { get; }

		// @property (readonly, nonatomic) STPPaymentIntentLastPaymentError * _Nullable lastPaymentError;
		[NullAllowed, Export("lastPaymentError")]
		STPPaymentIntentLastPaymentError LastPaymentError { get; }

		// @property (readonly, nonatomic) STPPaymentIntentShippingDetails * _Nullable shipping;
		[NullAllowed, Export("shipping")]
		STPPaymentIntentShippingDetails Shipping { get; }

		// @property (readonly, nonatomic) STPIntentAction * _Nullable nextSourceAction __attribute__((deprecated("Use nextAction instead", "nextAction")));
		[NullAllowed, Export("nextSourceAction")]
		STPIntentAction NextSourceAction { get; }
	}

	// @interface STPPaymentIntentLastPaymentError : NSObject <STPAPIResponseDecodable>
	[BaseType(typeof(NSObject))]
	interface STPPaymentIntentLastPaymentError
	{
		// @property (readonly, nonatomic) NSString * _Nullable code;
		[NullAllowed, Export("code")]
		string Code { get; }

		// @property (readonly, nonatomic) NSString * _Nullable declineCode;
		[NullAllowed, Export("declineCode")]
		string DeclineCode { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull docURL;
		[Export("docURL")]
		string DocURL { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull message;
		[Export("message")]
		string Message { get; }

		// @property (readonly, nonatomic) NSString * _Nullable param;
		[NullAllowed, Export("param")]
		string Param { get; }

		// @property (readonly, nonatomic) STPPaymentMethod * _Nullable paymentMethod;
		[NullAllowed, Export("paymentMethod")]
		STPPaymentMethod PaymentMethod { get; }

		// @property (readonly, nonatomic) STPPaymentIntentLastPaymentErrorType type;
		[Export("type")]
		STPPaymentIntentLastPaymentErrorType Type { get; }
	}

	// @interface STPPaymentIntentParams : NSObject <NSCopying, STPFormEncodable>
	[BaseType(typeof(NSObject))]
	interface STPPaymentIntentParams : INSCopying
	{
		// -(instancetype _Nonnull)initWithClientSecret:(NSString * _Nonnull)clientSecret;
		[Export("initWithClientSecret:")]
		IntPtr Constructor(string clientSecret);

		// @property (readonly, copy, nonatomic) NSString * _Nullable stripeId;
		[NullAllowed, Export("stripeId")]
		string StripeId { get; }

		// @property (copy, nonatomic) NSString * _Nonnull clientSecret;
		[Export("clientSecret")]
		string ClientSecret { get; set; }

		// @property (nonatomic, strong) STPPaymentMethodParams * _Nullable paymentMethodParams;
		[NullAllowed, Export("paymentMethodParams", ArgumentSemantic.Strong)]
		STPPaymentMethodParams PaymentMethodParams { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable paymentMethodId;
		[NullAllowed, Export("paymentMethodId")]
		string PaymentMethodId { get; set; }

		// -(void)configureWithPaymentResult:(STPPaymentResult * _Nonnull)paymentResult;
		[Export("configureWithPaymentResult:")]
		void ConfigureWithPaymentResult(STPPaymentResult paymentResult);

		// @property (nonatomic, strong) STPSourceParams * _Nullable sourceParams;
		[NullAllowed, Export("sourceParams", ArgumentSemantic.Strong)]
		STPSourceParams SourceParams { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable sourceId;
		[NullAllowed, Export("sourceId")]
		string SourceId { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable receiptEmail;
		[NullAllowed, Export("receiptEmail")]
		string ReceiptEmail { get; set; }

		// @property (nonatomic, strong) NSNumber * _Nullable savePaymentMethod;
		[NullAllowed, Export("savePaymentMethod", ArgumentSemantic.Strong)]
		NSNumber SavePaymentMethod { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable returnURL;
		[NullAllowed, Export("returnURL")]
		string ReturnURL { get; set; }

		// @property (nonatomic) NSNumber * _Nullable setupFutureUsage;
		[NullAllowed, Export("setupFutureUsage", ArgumentSemantic.Assign)]
		NSNumber SetupFutureUsage { get; set; }

		// @property (nonatomic) NSNumber * _Nullable useStripeSDK;
		[NullAllowed, Export("useStripeSDK", ArgumentSemantic.Assign)]
		NSNumber UseStripeSDK { get; set; }

		// @property (nonatomic) STPMandateDataParams * _Nullable mandateData;
		[NullAllowed, Export("mandateData", ArgumentSemantic.Assign)]
		STPMandateDataParams MandateData { get; set; }

		// @property (nonatomic) NSString * _Nullable mandate;
		[NullAllowed, Export("mandate")]
		string Mandate { get; set; }

		// @property (nonatomic) STPConfirmPaymentMethodOptions * _Nullable paymentMethodOptions;
		[NullAllowed, Export("paymentMethodOptions", ArgumentSemantic.Assign)]
		STPConfirmPaymentMethodOptions PaymentMethodOptions { get; set; }

		// @property (nonatomic) STPPaymentIntentShippingDetailsParams * _Nullable shipping;
		[NullAllowed, Export("shipping", ArgumentSemantic.Assign)]
		STPPaymentIntentShippingDetailsParams Shipping { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable returnUrl __attribute__((deprecated("returnUrl has been renamed to returnURL", "returnURL")));
		[NullAllowed, Export("returnUrl")]
		string ReturnUrl { get; set; }

		// @property (nonatomic, strong) NSNumber * _Nullable saveSourceToCustomer __attribute__((deprecated("saveSourceToCustomer has been renamed to savePaymentMethod", "saveSourceToCustomer")));
		[NullAllowed, Export("saveSourceToCustomer", ArgumentSemantic.Strong)]
		NSNumber SaveSourceToCustomer { get; set; }
	}

	// @interface Utilities (STPPaymentIntentParams)
	[Category]
	[BaseType(typeof(STPPaymentIntentParams))]
	interface STPPaymentIntentParams_Utilities
	{
		// +(BOOL)isClientSecretValid:(NSString * _Nonnull)clientSecret;
		[Static]
		[Export("isClientSecretValid:")]
		bool IsClientSecretValid(string clientSecret);
	}

	// @interface STPPaymentIntentShippingDetails : NSObject <STPAPIResponseDecodable>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface STPPaymentIntentShippingDetails
	{
		// @property (readonly, nonatomic) STPPaymentIntentShippingDetailsAddress * _Nullable address;
		[NullAllowed, Export("address")]
		STPPaymentIntentShippingDetailsAddress Address { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export("name")]
		string Name { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable carrier;
		[NullAllowed, Export("carrier")]
		string Carrier { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable phone;
		[NullAllowed, Export("phone")]
		string Phone { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable trackingNumber;
		[NullAllowed, Export("trackingNumber")]
		string TrackingNumber { get; }
	}

	// @interface STPPaymentIntentShippingDetailsAddress : NSObject <STPAPIResponseDecodable>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface STPPaymentIntentShippingDetailsAddress
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable city;
		[NullAllowed, Export("city")]
		string City { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable country;
		[NullAllowed, Export("country")]
		string Country { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable line1;
		[NullAllowed, Export("line1")]
		string Line1 { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable line2;
		[NullAllowed, Export("line2")]
		string Line2 { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable postalCode;
		[NullAllowed, Export("postalCode")]
		string PostalCode { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable state;
		[NullAllowed, Export("state")]
		string State { get; }
	}

	// @interface STPPaymentIntentShippingDetailsAddressParams : NSObject <NSCopying, STPFormEncodable>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface STPPaymentIntentShippingDetailsAddressParams : INSCopying
	{
		// @property (copy, nonatomic) NSString * _Nullable city;
		[NullAllowed, Export("city")]
		string City { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable country;
		[NullAllowed, Export("country")]
		string Country { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull line1;
		[Export("line1")]
		string Line1 { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable line2;
		[NullAllowed, Export("line2")]
		string Line2 { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable postalCode;
		[NullAllowed, Export("postalCode")]
		string PostalCode { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable state;
		[NullAllowed, Export("state")]
		string State { get; set; }

		// -(instancetype _Nonnull)initWithLine1:(NSString * _Nonnull)line1;
		[Export("initWithLine1:")]
		IntPtr Constructor(string line1);
	}

	// @interface STPPaymentIntentShippingDetailsParams : NSObject <NSCopying, STPFormEncodable>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface STPPaymentIntentShippingDetailsParams : INSCopying
	{
		// @property (nonatomic) STPPaymentIntentShippingDetailsAddressParams * _Nonnull address;
		[Export("address", ArgumentSemantic.Assign)]
		STPPaymentIntentShippingDetailsAddressParams Address { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull name;
		[Export("name")]
		string Name { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable carrier;
		[NullAllowed, Export("carrier")]
		string Carrier { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable phone;
		[NullAllowed, Export("phone")]
		string Phone { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable trackingNumber;
		[NullAllowed, Export("trackingNumber")]
		string TrackingNumber { get; set; }

		// -(instancetype _Nonnull)initWithAddress:(STPPaymentIntentShippingDetailsAddressParams * _Nonnull)address name:(NSString * _Nonnull)name;
		[Export("initWithAddress:name:")]
		IntPtr Constructor(STPPaymentIntentShippingDetailsAddressParams address, string name);
	}

	// @interface STPPaymentMethod : NSObject <STPAPIResponseDecodable, STPPaymentOption>
	[BaseType(typeof(NSObject))]
	interface STPPaymentMethod : STPPaymentOption
	{
		// @property (readonly, nonatomic) NSString * _Nonnull stripeId;
		[Export("stripeId")]
		string StripeId { get; }

		// @property (readonly, nonatomic) NSDate * _Nullable created;
		[NullAllowed, Export("created")]
		NSDate Created { get; }

		// @property (readonly, nonatomic) BOOL liveMode;
		[Export("liveMode")]
		bool LiveMode { get; }

		// @property (readonly, nonatomic) STPPaymentMethodType type;
		[Export("type")]
		STPPaymentMethodType Type { get; }

		// @property (readonly, nonatomic) STPPaymentMethodBillingDetails * _Nullable billingDetails;
		[NullAllowed, Export("billingDetails")]
		STPPaymentMethodBillingDetails BillingDetails { get; }

		// @property (readonly, nonatomic) STPPaymentMethodAlipay * _Nullable alipay;
		[NullAllowed, Export("alipay")]
		STPPaymentMethodAlipay Alipay { get; }

		// @property (readonly, nonatomic) STPPaymentMethodCard * _Nullable card;
		[NullAllowed, Export("card")]
		STPPaymentMethodCard Card { get; }

		// @property (readonly, nonatomic) STPPaymentMethodiDEAL * _Nullable iDEAL;
		[NullAllowed, Export("iDEAL")]
		STPPaymentMethodiDEAL IDEAL { get; }

		// @property (readonly, nonatomic) STPPaymentMethodFPX * _Nullable fpx;
		[NullAllowed, Export("fpx")]
		STPPaymentMethodFPX Fpx { get; }

		// @property (readonly, nonatomic) STPPaymentMethodCardPresent * _Nullable cardPresent;
		[NullAllowed, Export("cardPresent")]
		STPPaymentMethodCardPresent CardPresent { get; }

		// @property (readonly, nonatomic) STPPaymentMethodSEPADebit * _Nullable sepaDebit;
		[NullAllowed, Export("sepaDebit")]
		STPPaymentMethodSEPADebit SepaDebit { get; }

		// @property (readonly, nonatomic) STPPaymentMethodBacsDebit * _Nullable bacsDebit;
		[NullAllowed, Export("bacsDebit")]
		STPPaymentMethodBacsDebit BacsDebit { get; }

		// @property (readonly, nonatomic) STPPaymentMethodAUBECSDebit * _Nullable auBECSDebit;
		[NullAllowed, Export("auBECSDebit")]
		STPPaymentMethodAUBECSDebit AuBECSDebit { get; }

		// @property (readonly, nonatomic) STPPaymentMethodGiropay * _Nullable giropay;
		[NullAllowed, Export("giropay")]
		STPPaymentMethodGiropay Giropay { get; }

		// @property (readonly, nonatomic) STPPaymentMethodEPS * _Nullable eps;
		[NullAllowed, Export("eps")]
		STPPaymentMethodEPS Eps { get; }

		// @property (readonly, nonatomic) STPPaymentMethodPrzelewy24 * _Nullable przelewy24;
		[NullAllowed, Export("przelewy24")]
		STPPaymentMethodPrzelewy24 Przelewy24 { get; }

		// @property (readonly, nonatomic) STPPaymentMethodBancontact * _Nullable bancontact;
		[NullAllowed, Export("bancontact")]
		STPPaymentMethodBancontact Bancontact { get; }

		// @property (readonly, nonatomic) NSString * _Nullable customerId;
		[NullAllowed, Export("customerId")]
		string CustomerId { get; }

		// @property (readonly, nonatomic) DEPRECATED_MSG_ATTRIBUTE("Metadata is no longer returned to clients using publishable keys. Retrieve them on your server using yoursecret key instead.") NSDictionary<NSString *,NSString *> * metadata __attribute__((deprecated("Metadata is no longer returned to clients using publishable keys. Retrieve them on your server using yoursecret key instead.")));
		[Export("metadata")]
		NSDictionary<NSString, NSString> Metadata { get; }
	}

	// @interface STPPaymentMethodAddress : NSObject <STPAPIResponseDecodable, STPFormEncodable>
	[BaseType(typeof(NSObject))]
	interface STPPaymentMethodAddress
	{
		// @property (readwrite, copy, nonatomic) NSString * _Nullable city;
		[NullAllowed, Export("city")]
		string City { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * _Nullable country;
		[NullAllowed, Export("country")]
		string Country { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * _Nullable line1;
		[NullAllowed, Export("line1")]
		string Line1 { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * _Nullable line2;
		[NullAllowed, Export("line2")]
		string Line2 { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * _Nullable postalCode;
		[NullAllowed, Export("postalCode")]
		string PostalCode { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * _Nullable state;
		[NullAllowed, Export("state")]
		string State { get; set; }

		// -(instancetype _Nonnull)initWithAddress:(STPAddress * _Nonnull)address;
		[Export("initWithAddress:")]
		IntPtr Constructor(STPAddress address);
	}

	// @interface STPPaymentMethodAlipay : NSObject <STPAPIResponseDecodable>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface STPPaymentMethodAlipay
	{
	}

	// @interface STPPaymentMethodAlipayParams : NSObject <STPFormEncodable>
	[BaseType(typeof(NSObject))]
	interface STPPaymentMethodAlipayParams
	{
	}

	// @interface STPPaymentMethodAUBECSDebit : NSObject <STPAPIResponseDecodable>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface STPPaymentMethodAUBECSDebit
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull bsbNumber;
		[Export("bsbNumber")]
		string BsbNumber { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull fingerprint;
		[Export("fingerprint")]
		string Fingerprint { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull last4;
		[Export("last4")]
		string Last4 { get; }
	}

	// @interface STPPaymentMethodAUBECSDebitParams : NSObject <STPFormEncodable>
	[BaseType(typeof(NSObject))]
	interface STPPaymentMethodAUBECSDebitParams
	{
		// @property (copy, nonatomic) NSString * _Nonnull accountNumber;
		[Export("accountNumber")]
		string AccountNumber { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull bsbNumber;
		[Export("bsbNumber")]
		string BsbNumber { get; set; }
	}

	// @interface STPPaymentMethodBacsDebit : NSObject <STPAPIResponseDecodable>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface STPPaymentMethodBacsDebit
	{
		// @property (readonly, nonatomic) NSString * _Nullable fingerprint;
		[NullAllowed, Export("fingerprint")]
		string Fingerprint { get; }

		// @property (readonly, nonatomic) NSString * _Nullable last4;
		[NullAllowed, Export("last4")]
		string Last4 { get; }

		// @property (readonly, nonatomic) NSString * _Nullable sortCode;
		[NullAllowed, Export("sortCode")]
		string SortCode { get; }
	}

	// @interface STPPaymentMethodBacsDebitParams : NSObject <STPFormEncodable>
	[BaseType(typeof(NSObject))]
	interface STPPaymentMethodBacsDebitParams
	{
		// @property (copy, nonatomic) NSString * _Nonnull accountNumber;
		[Export("accountNumber")]
		string AccountNumber { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull sortCode;
		[Export("sortCode")]
		string SortCode { get; set; }
	}

	// @interface STPPaymentMethodBancontact : NSObject <STPAPIResponseDecodable>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface STPPaymentMethodBancontact
	{
	}

	// @interface STPPaymentMethodBancontactParams : NSObject <STPFormEncodable>
	[BaseType(typeof(NSObject))]
	interface STPPaymentMethodBancontactParams
	{
	}

	// @interface STPPaymentMethodBillingDetails : NSObject <STPAPIResponseDecodable, STPFormEncodable>
	[BaseType(typeof(NSObject))]
	interface STPPaymentMethodBillingDetails
	{
		// @property (nonatomic, strong) STPPaymentMethodAddress * _Nullable address;
		[NullAllowed, Export("address", ArgumentSemantic.Strong)]
		STPPaymentMethodAddress Address { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable email;
		[NullAllowed, Export("email")]
		string Email { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export("name")]
		string Name { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable phone;
		[NullAllowed, Export("phone")]
		string Phone { get; set; }
	}

	// @interface STPPaymentMethodCardChecks : NSObject <STPAPIResponseDecodable>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface STPPaymentMethodCardChecks
	{
		// @property (readonly, nonatomic) STPPaymentMethodCardCheckResult addressLine1Check __attribute__((deprecated("Card check values are no longer returned to clients using publishable keys. Retrieve them on your server using yoursecret key instead.")));
		[Export("addressLine1Check")]
		STPPaymentMethodCardCheckResult AddressLine1Check { get; }

		// @property (readonly, nonatomic) STPPaymentMethodCardCheckResult addressPostalCodeCheck __attribute__((deprecated("Card check values are no longer returned to clients using publishable keys. Retrieve them on your server using yoursecret key instead.")));
		[Export("addressPostalCodeCheck")]
		STPPaymentMethodCardCheckResult AddressPostalCodeCheck { get; }

		// @property (readonly, nonatomic) STPPaymentMethodCardCheckResult cvcCheck __attribute__((deprecated("Card check values are no longer returned to clients using publishable keys. Retrieve them on your server using yoursecret key instead.")));
		[Export("cvcCheck")]
		STPPaymentMethodCardCheckResult CvcCheck { get; }
	}

	// @interface STPPaymentMethodCardNetworks : NSObject <STPAPIResponseDecodable>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface STPPaymentMethodCardNetworks
	{
		// @property (readonly, nonatomic) NSArray<NSString *> * _Nonnull available;
		[Export("available")]
		string[] Available { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable preferred;
		[NullAllowed, Export("preferred")]
		string Preferred { get; }
	}

	// @interface STPPaymentMethodCardPresent : NSObject <STPAPIResponseDecodable>
	[BaseType(typeof(NSObject))]
	interface STPPaymentMethodCardPresent
	{
	}

	// @interface STPPaymentMethodCardWallet : NSObject <STPAPIResponseDecodable>
	[BaseType(typeof(NSObject))]
	interface STPPaymentMethodCardWallet
	{
		// @property (readonly, nonatomic) STPPaymentMethodCardWalletType type;
		[Export("type")]
		STPPaymentMethodCardWalletType Type { get; }

		// @property (readonly, nonatomic) STPPaymentMethodCardWalletMasterpass * _Nullable masterpass;
		[NullAllowed, Export("masterpass")]
		STPPaymentMethodCardWalletMasterpass Masterpass { get; }

		// @property (readonly, nonatomic) STPPaymentMethodCardWalletVisaCheckout * _Nullable visaCheckout;
		[NullAllowed, Export("visaCheckout")]
		STPPaymentMethodCardWalletVisaCheckout VisaCheckout { get; }
	}

	// @interface STPPaymentMethodCardWalletMasterpass : NSObject <STPAPIResponseDecodable>
	[BaseType(typeof(NSObject))]
	interface STPPaymentMethodCardWalletMasterpass
	{
		// @property (readonly, nonatomic) NSString * _Nullable email;
		[NullAllowed, Export("email")]
		string Email { get; }

		// @property (readonly, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export("name")]
		string Name { get; }

		// @property (readonly, nonatomic) STPPaymentMethodAddress * _Nullable billingAddress;
		[NullAllowed, Export("billingAddress")]
		STPPaymentMethodAddress BillingAddress { get; }

		// @property (readonly, nonatomic) STPPaymentMethodAddress * _Nullable shippingAddress;
		[NullAllowed, Export("shippingAddress")]
		STPPaymentMethodAddress ShippingAddress { get; }
	}

	// @interface STPPaymentMethodCardWalletVisaCheckout : NSObject <STPAPIResponseDecodable>
	[BaseType(typeof(NSObject))]
	interface STPPaymentMethodCardWalletVisaCheckout
	{
		// @property (readonly, nonatomic) NSString * _Nullable email;
		[NullAllowed, Export("email")]
		string Email { get; }

		// @property (readonly, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export("name")]
		string Name { get; }

		// @property (readonly, nonatomic) STPPaymentMethodAddress * _Nullable billingAddress;
		[NullAllowed, Export("billingAddress")]
		STPPaymentMethodAddress BillingAddress { get; }

		// @property (readonly, nonatomic) STPPaymentMethodAddress * _Nullable shippingAddress;
		[NullAllowed, Export("shippingAddress")]
		STPPaymentMethodAddress ShippingAddress { get; }
	}

	// @interface STPPaymentMethodCardParams : NSObject <STPFormEncodable>
	[BaseType(typeof(NSObject))]
	interface STPPaymentMethodCardParams
	{
		// -(instancetype _Nonnull)initWithCardSourceParams:(STPCardParams * _Nonnull)cardSourceParams;
		[Export("initWithCardSourceParams:")]
		IntPtr Constructor(STPCardParams cardSourceParams);

		// @property (copy, nonatomic) NSString * _Nullable number;
		[NullAllowed, Export("number")]
		string Number { get; set; }

		// @property (nonatomic) NSNumber * _Nullable expMonth;
		[NullAllowed, Export("expMonth", ArgumentSemantic.Assign)]
		NSNumber ExpMonth { get; set; }

		// @property (nonatomic) NSNumber * _Nullable expYear;
		[NullAllowed, Export("expYear", ArgumentSemantic.Assign)]
		NSNumber ExpYear { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable token;
		[NullAllowed, Export("token")]
		string Token { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable cvc;
		[NullAllowed, Export("cvc")]
		string Cvc { get; set; }

		// @property (readonly, nonatomic) NSString * _Nullable last4;
		[NullAllowed, Export("last4")]
		string Last4 { get; }
	}

	// @interface STPPaymentMethodiDEAL : NSObject <STPAPIResponseDecodable>
	[BaseType(typeof(NSObject))]
	interface STPPaymentMethodiDEAL
	{
		// @property (readonly, nonatomic) NSString * _Nullable bankName;
		[NullAllowed, Export("bankName")]
		string BankName { get; }

		// @property (readonly, nonatomic) NSString * _Nullable bankIdentifierCode;
		[NullAllowed, Export("bankIdentifierCode")]
		string BankIdentifierCode { get; }
	}

	// @interface STPPaymentMethodiDEALParams : NSObject <STPFormEncodable>
	[BaseType(typeof(NSObject))]
	interface STPPaymentMethodiDEALParams
	{
		// @property (copy, nonatomic) NSString * _Nullable bankName;
		[NullAllowed, Export("bankName")]
		string BankName { get; set; }
	}

	// @interface STPPaymentMethodEPS : NSObject <STPAPIResponseDecodable>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface STPPaymentMethodEPS
	{
	}

	// @interface STPPaymentMethodEPSParams : NSObject <STPFormEncodable>
	[BaseType(typeof(NSObject))]
	interface STPPaymentMethodEPSParams
	{
	}

	// @interface STPPaymentMethodFPX : NSObject <STPAPIResponseDecodable>
	[BaseType(typeof(NSObject))]
	interface STPPaymentMethodFPX
	{
		// @property (readonly, nonatomic) NSString * _Nullable bankIdentifierCode;
		[NullAllowed, Export("bankIdentifierCode")]
		string BankIdentifierCode { get; }
	}

	// @interface STPPaymentMethodFPXParams : NSObject <STPFormEncodable>
	[BaseType(typeof(NSObject))]
	interface STPPaymentMethodFPXParams
	{
		// @property (assign, nonatomic) STPFPXBankBrand bank;
		[Export("bank", ArgumentSemantic.Assign)]
		STPFPXBankBrand Bank { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable rawBankString;
		[NullAllowed, Export("rawBankString")]
		string RawBankString { get; set; }
	}

	// @interface STPPaymentMethodGiropay : NSObject <STPAPIResponseDecodable>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface STPPaymentMethodGiropay
	{
	}

	// @interface STPPaymentMethodGiropayParams : NSObject <STPFormEncodable>
	[BaseType(typeof(NSObject))]
	interface STPPaymentMethodGiropayParams
	{
	}

	// @interface STPPaymentMethodParams : NSObject <STPFormEncodable, STPPaymentOption>
	[BaseType(typeof(NSObject))]
	interface STPPaymentMethodParams : STPPaymentOption
	{
		// @property (readonly, nonatomic) STPPaymentMethodType type;
		[Export("type")]
		STPPaymentMethodType Type { get; }

		// @property (copy, nonatomic) NSString * _Nonnull rawTypeString;
		[Export("rawTypeString")]
		string RawTypeString { get; set; }

		// @property (nonatomic, strong) STPPaymentMethodBillingDetails * _Nullable billingDetails;
		[NullAllowed, Export("billingDetails", ArgumentSemantic.Strong)]
		STPPaymentMethodBillingDetails BillingDetails { get; set; }

		// @property (nonatomic, strong) STPPaymentMethodCardParams * _Nullable card;
		[NullAllowed, Export("card", ArgumentSemantic.Strong)]
		STPPaymentMethodCardParams Card { get; set; }

		// @property (nonatomic) STPPaymentMethodAlipayParams * _Nullable alipay;
		[NullAllowed, Export("alipay", ArgumentSemantic.Assign)]
		STPPaymentMethodAlipayParams Alipay { get; set; }

		// @property (nonatomic) STPPaymentMethodiDEALParams * _Nullable iDEAL;
		[NullAllowed, Export("iDEAL", ArgumentSemantic.Assign)]
		STPPaymentMethodiDEALParams IDEAL { get; set; }

		// @property (nonatomic) STPPaymentMethodFPXParams * _Nullable fpx;
		[NullAllowed, Export("fpx", ArgumentSemantic.Assign)]
		STPPaymentMethodFPXParams Fpx { get; set; }

		// @property (nonatomic) STPPaymentMethodSEPADebitParams * _Nullable sepaDebit;
		[NullAllowed, Export("sepaDebit", ArgumentSemantic.Assign)]
		STPPaymentMethodSEPADebitParams SepaDebit { get; set; }

		// @property (nonatomic) STPPaymentMethodBacsDebitParams * _Nullable bacsDebit;
		[NullAllowed, Export("bacsDebit", ArgumentSemantic.Assign)]
		STPPaymentMethodBacsDebitParams BacsDebit { get; set; }

		// @property (nonatomic) STPPaymentMethodAUBECSDebitParams * _Nullable auBECSDebit;
		[NullAllowed, Export("auBECSDebit", ArgumentSemantic.Assign)]
		STPPaymentMethodAUBECSDebitParams AuBECSDebit { get; set; }

		// @property (nonatomic) STPPaymentMethodGiropayParams * _Nullable giropay;
		[NullAllowed, Export("giropay", ArgumentSemantic.Assign)]
		STPPaymentMethodGiropayParams Giropay { get; set; }

		// @property (nonatomic) STPPaymentMethodPrzelewy24Params * _Nullable przelewy24;
		[NullAllowed, Export("przelewy24", ArgumentSemantic.Assign)]
		STPPaymentMethodPrzelewy24Params Przelewy24 { get; set; }

		// @property (nonatomic) STPPaymentMethodEPSParams * _Nullable eps;
		[NullAllowed, Export("eps", ArgumentSemantic.Assign)]
		STPPaymentMethodEPSParams Eps { get; set; }

		// @property (nonatomic) STPPaymentMethodBancontactParams * _Nullable bancontact;
		[NullAllowed, Export("bancontact", ArgumentSemantic.Assign)]
		STPPaymentMethodBancontactParams Bancontact { get; set; }

		// @property (copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nullable metadata;
		[NullAllowed, Export("metadata", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSString> Metadata { get; set; }

		// +(STPPaymentMethodParams * _Nonnull)paramsWithCard:(STPPaymentMethodCardParams * _Nonnull)card billingDetails:(STPPaymentMethodBillingDetails * _Nullable)billingDetails metadata:(NSDictionary<NSString *,NSString *> * _Nullable)metadata;
		[Static]
		[Export("paramsWithCard:billingDetails:metadata:")]
		STPPaymentMethodParams ParamsWithCard(STPPaymentMethodCardParams card, [NullAllowed] STPPaymentMethodBillingDetails billingDetails, [NullAllowed] NSDictionary<NSString, NSString> metadata);

		// +(STPPaymentMethodParams * _Nonnull)paramsWithiDEAL:(STPPaymentMethodiDEALParams * _Nonnull)iDEAL billingDetails:(STPPaymentMethodBillingDetails * _Nullable)billingDetails metadata:(NSDictionary<NSString *,NSString *> * _Nullable)metadata;
		[Static]
		[Export("paramsWithiDEAL:billingDetails:metadata:")]
		STPPaymentMethodParams ParamsWithiDEAL(STPPaymentMethodiDEALParams iDEAL, [NullAllowed] STPPaymentMethodBillingDetails billingDetails, [NullAllowed] NSDictionary<NSString, NSString> metadata);

		// +(STPPaymentMethodParams * _Nonnull)paramsWithFPX:(STPPaymentMethodFPXParams * _Nonnull)fpx billingDetails:(STPPaymentMethodBillingDetails * _Nullable)billingDetails metadata:(NSDictionary<NSString *,NSString *> * _Nullable)metadata;
		[Static]
		[Export("paramsWithFPX:billingDetails:metadata:")]
		STPPaymentMethodParams ParamsWithFPX(STPPaymentMethodFPXParams fpx, [NullAllowed] STPPaymentMethodBillingDetails billingDetails, [NullAllowed] NSDictionary<NSString, NSString> metadata);

		// +(STPPaymentMethodParams * _Nullable)paramsWithSEPADebit:(STPPaymentMethodSEPADebitParams * _Nonnull)sepaDebit billingDetails:(STPPaymentMethodBillingDetails * _Nonnull)billingDetails metadata:(NSDictionary<NSString *,NSString *> * _Nullable)metadata;
		[Static]
		[Export("paramsWithSEPADebit:billingDetails:metadata:")]
		[return: NullAllowed]
		STPPaymentMethodParams ParamsWithSEPADebit(STPPaymentMethodSEPADebitParams sepaDebit, STPPaymentMethodBillingDetails billingDetails, [NullAllowed] NSDictionary<NSString, NSString> metadata);

		// +(STPPaymentMethodParams * _Nullable)paramsWithBacsDebit:(STPPaymentMethodBacsDebitParams * _Nonnull)bacsDebit billingDetails:(STPPaymentMethodBillingDetails * _Nonnull)billingDetails metadata:(NSDictionary<NSString *,NSString *> * _Nullable)metadata;
		[Static]
		[Export("paramsWithBacsDebit:billingDetails:metadata:")]
		[return: NullAllowed]
		STPPaymentMethodParams ParamsWithBacsDebit(STPPaymentMethodBacsDebitParams bacsDebit, STPPaymentMethodBillingDetails billingDetails, [NullAllowed] NSDictionary<NSString, NSString> metadata);

		// +(STPPaymentMethodParams * _Nullable)paramsWithAUBECSDebit:(STPPaymentMethodAUBECSDebitParams * _Nonnull)auBECSDebit billingDetails:(STPPaymentMethodBillingDetails * _Nonnull)billingDetails metadata:(NSDictionary<NSString *,NSString *> * _Nullable)metadata;
		[Static]
		[Export("paramsWithAUBECSDebit:billingDetails:metadata:")]
		[return: NullAllowed]
		STPPaymentMethodParams ParamsWithAUBECSDebit(STPPaymentMethodAUBECSDebitParams auBECSDebit, STPPaymentMethodBillingDetails billingDetails, [NullAllowed] NSDictionary<NSString, NSString> metadata);

		// +(STPPaymentMethodParams * _Nullable)paramsWithGiropay:(STPPaymentMethodGiropayParams * _Nonnull)giropay billingDetails:(STPPaymentMethodBillingDetails * _Nonnull)billingDetails metadata:(NSDictionary<NSString *,NSString *> * _Nullable)metadata;
		[Static]
		[Export("paramsWithGiropay:billingDetails:metadata:")]
		[return: NullAllowed]
		STPPaymentMethodParams ParamsWithGiropay(STPPaymentMethodGiropayParams giropay, STPPaymentMethodBillingDetails billingDetails, [NullAllowed] NSDictionary<NSString, NSString> metadata);

		// +(STPPaymentMethodParams * _Nonnull)paramsWithEPS:(STPPaymentMethodEPSParams * _Nonnull)eps billingDetails:(STPPaymentMethodBillingDetails * _Nonnull)billingDetails metadata:(NSDictionary<NSString *,NSString *> * _Nullable)metadata;
		[Static]
		[Export("paramsWithEPS:billingDetails:metadata:")]
		STPPaymentMethodParams ParamsWithEPS(STPPaymentMethodEPSParams eps, STPPaymentMethodBillingDetails billingDetails, [NullAllowed] NSDictionary<NSString, NSString> metadata);

		// +(STPPaymentMethodParams * _Nullable)paramsWithPrzelewy24:(STPPaymentMethodPrzelewy24Params * _Nonnull)przelewy24 billingDetails:(STPPaymentMethodBillingDetails * _Nonnull)billingDetails metadata:(NSDictionary<NSString *,NSString *> * _Nullable)metadata;
		[Static]
		[Export("paramsWithPrzelewy24:billingDetails:metadata:")]
		[return: NullAllowed]
		STPPaymentMethodParams ParamsWithPrzelewy24(STPPaymentMethodPrzelewy24Params przelewy24, STPPaymentMethodBillingDetails billingDetails, [NullAllowed] NSDictionary<NSString, NSString> metadata);

		// +(STPPaymentMethodParams * _Nullable)paramsWithBancontact:(STPPaymentMethodBancontactParams * _Nonnull)bancontact billingDetails:(STPPaymentMethodBillingDetails * _Nonnull)billingDetails metadata:(NSDictionary<NSString *,NSString *> * _Nullable)metadata;
		[Static]
		[Export("paramsWithBancontact:billingDetails:metadata:")]
		[return: NullAllowed]
		STPPaymentMethodParams ParamsWithBancontact(STPPaymentMethodBancontactParams bancontact, STPPaymentMethodBillingDetails billingDetails, [NullAllowed] NSDictionary<NSString, NSString> metadata);

		// +(STPPaymentMethodParams * _Nonnull)paramsWithAlipay:(STPPaymentMethodAlipayParams * _Nonnull)alipay billingDetails:(STPPaymentMethodBillingDetails * _Nullable)billingDetails metadata:(NSDictionary<NSString *,NSString *> * _Nullable)metadata;
		[Static]
		[Export("paramsWithAlipay:billingDetails:metadata:")]
		STPPaymentMethodParams ParamsWithAlipay(STPPaymentMethodAlipayParams alipay, [NullAllowed] STPPaymentMethodBillingDetails billingDetails, [NullAllowed] NSDictionary<NSString, NSString> metadata);

		// +(STPPaymentMethodParams * _Nullable)paramsWithSingleUsePaymentMethod:(STPPaymentMethod * _Nonnull)paymentMethod;
		[Static]
		[Export("paramsWithSingleUsePaymentMethod:")]
		[return: NullAllowed]
		STPPaymentMethodParams ParamsWithSingleUsePaymentMethod(STPPaymentMethod paymentMethod);
	}

	// @interface STPPaymentMethodPrzelewy24 : NSObject <STPAPIResponseDecodable>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface STPPaymentMethodPrzelewy24
	{
	}

	// @interface STPPaymentMethodPrzelewy24Params : NSObject <STPFormEncodable>
	[BaseType(typeof(NSObject))]
	interface STPPaymentMethodPrzelewy24Params
	{
	}

	// @interface STPPaymentMethodSEPADebit : NSObject <STPAPIResponseDecodable>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface STPPaymentMethodSEPADebit
	{
		// @property (readonly, nonatomic) NSString * _Nullable last4;
		[NullAllowed, Export("last4")]
		string Last4 { get; }

		// @property (readonly, nonatomic) NSString * _Nullable bankCode;
		[NullAllowed, Export("bankCode")]
		string BankCode { get; }

		// @property (readonly, nonatomic) NSString * _Nullable branchCode;
		[NullAllowed, Export("branchCode")]
		string BranchCode { get; }

		// @property (readonly, nonatomic) NSString * _Nullable country;
		[NullAllowed, Export("country")]
		string Country { get; }

		// @property (readonly, nonatomic) NSString * _Nullable fingerprint;
		[NullAllowed, Export("fingerprint")]
		string Fingerprint { get; }

		// @property (readonly, nonatomic) NSString * _Nullable mandate;
		[NullAllowed, Export("mandate")]
		string Mandate { get; }
	}

	// @interface STPPaymentMethodSEPADebitParams : NSObject <STPFormEncodable>
	[BaseType(typeof(NSObject))]
	interface STPPaymentMethodSEPADebitParams
	{
		// @property (copy, nonatomic) NSString * _Nullable iban;
		[NullAllowed, Export("iban")]
		string Iban { get; set; }
	}

	// @interface STPPaymentMethodThreeDSecureUsage : NSObject <STPAPIResponseDecodable>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface STPPaymentMethodThreeDSecureUsage
	{
		// @property (readonly, nonatomic) BOOL supported;
		[Export("supported")]
		bool Supported { get; }
	}

	// @interface STPPaymentOptionsViewController : STPCoreViewController
	[BaseType(typeof(STPCoreViewController))]
	interface STPPaymentOptionsViewController
	{
		[Wrap("WeakDelegate")]
		[NullAllowed]
		STPPaymentOptionsViewControllerDelegate Delegate { get; }

		// @property (readonly, nonatomic, weak) id<STPPaymentOptionsViewControllerDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; }

		// -(instancetype _Nonnull)initWithPaymentContext:(STPPaymentContext * _Nonnull)paymentContext;
		[Export("initWithPaymentContext:")]
		IntPtr Constructor(STPPaymentContext paymentContext);

		// -(instancetype _Nonnull)initWithConfiguration:(STPPaymentConfiguration * _Nonnull)configuration theme:(STPTheme * _Nonnull)theme customerContext:(STPCustomerContext * _Nonnull)customerContext delegate:(id<STPPaymentOptionsViewControllerDelegate> _Nonnull)delegate;
		[Export("initWithConfiguration:theme:customerContext:delegate:")]
		IntPtr Constructor(STPPaymentConfiguration configuration, STPTheme theme, STPCustomerContext customerContext, STPPaymentOptionsViewControllerDelegate @delegate);

		// -(instancetype _Nonnull)initWithConfiguration:(STPPaymentConfiguration * _Nonnull)configuration theme:(STPTheme * _Nonnull)theme apiAdapter:(id<STPBackendAPIAdapter> _Nonnull)apiAdapter delegate:(id<STPPaymentOptionsViewControllerDelegate> _Nonnull)delegate;
		[Export("initWithConfiguration:theme:apiAdapter:delegate:")]
		IntPtr Constructor(STPPaymentConfiguration configuration, STPTheme theme, STPBackendAPIAdapter apiAdapter, STPPaymentOptionsViewControllerDelegate @delegate);

		// @property (nonatomic, strong) STPUserInformation * _Nullable prefilledInformation;
		[NullAllowed, Export("prefilledInformation", ArgumentSemantic.Strong)]
		STPUserInformation PrefilledInformation { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable defaultPaymentMethod;
		[NullAllowed, Export("defaultPaymentMethod")]
		string DefaultPaymentMethod { get; set; }

		// @property (nonatomic, strong) UIView * _Nonnull paymentOptionsViewControllerFooterView;
		[Export("paymentOptionsViewControllerFooterView", ArgumentSemantic.Strong)]
		UIView PaymentOptionsViewControllerFooterView { get; set; }

		// @property (nonatomic, strong) UIView * _Nonnull addCardViewControllerFooterView;
		[Export("addCardViewControllerFooterView", ArgumentSemantic.Strong)]
		UIView AddCardViewControllerFooterView { get; set; }

		// @property (nonatomic, strong) STPAPIClient * _Nonnull apiClient;
		[Export("apiClient", ArgumentSemantic.Strong)]
		STPAPIClient ApiClient { get; set; }

		// -(void)dismissWithCompletion:(STPVoidBlock _Nullable)completion;
		[Export("dismissWithCompletion:")]
		void DismissWithCompletion([NullAllowed] STPVoidBlock completion);
	}

	// @protocol STPPaymentOptionsViewControllerDelegate <NSObject>
	[Protocol, Model(AutoGeneratedName = true)]
	[BaseType(typeof(NSObject))]
	interface STPPaymentOptionsViewControllerDelegate
	{
		// @required -(void)paymentOptionsViewController:(STPPaymentOptionsViewController * _Nonnull)paymentOptionsViewController didFailToLoadWithError:(NSError * _Nonnull)error;
		[Abstract]
		[Export("paymentOptionsViewController:didFailToLoadWithError:")]
		void PaymentOptionsViewController(STPPaymentOptionsViewController paymentOptionsViewController, NSError error);

		// @required -(void)paymentOptionsViewControllerDidFinish:(STPPaymentOptionsViewController * _Nonnull)paymentOptionsViewController;
		[Abstract]
		[Export("paymentOptionsViewControllerDidFinish:")]
		void PaymentOptionsViewControllerDidFinish(STPPaymentOptionsViewController paymentOptionsViewController);

		// @required -(void)paymentOptionsViewControllerDidCancel:(STPPaymentOptionsViewController * _Nonnull)paymentOptionsViewController;
		[Abstract]
		[Export("paymentOptionsViewControllerDidCancel:")]
		void PaymentOptionsViewControllerDidCancel(STPPaymentOptionsViewController paymentOptionsViewController);

		// @optional -(void)paymentOptionsViewController:(STPPaymentOptionsViewController * _Nonnull)paymentOptionsViewController didSelectPaymentOption:(id<STPPaymentOption> _Nonnull)paymentOption;
		[Export("paymentOptionsViewController:didSelectPaymentOption:")]
		void PaymentOptionsViewController(STPPaymentOptionsViewController paymentOptionsViewController, STPPaymentOption paymentOption);
	}

	// @interface STPPushProvisioningContext : NSObject
	[BaseType(typeof(NSObject))]
	interface STPPushProvisioningContext
	{
		// @property (nonatomic, strong) STPAPIClient * _Nonnull apiClient;
		[Export("apiClient", ArgumentSemantic.Strong)]
		STPAPIClient ApiClient { get; set; }

		// +(PKAddPaymentPassRequestConfiguration * _Nonnull)requestConfigurationWithName:(NSString * _Nonnull)name description:(NSString * _Nullable)description last4:(NSString * _Nullable)last4 brand:(STPCardBrand)brand;
		[Static]
		[Export("requestConfigurationWithName:description:last4:brand:")]
		PKAddPaymentPassRequestConfiguration RequestConfigurationWithName(string name, [NullAllowed] string description, [NullAllowed] string last4, STPCardBrand brand);

		// -(instancetype _Nonnull)initWithKeyProvider:(id<STPIssuingCardEphemeralKeyProvider> _Nonnull)keyProvider;
		[Export("initWithKeyProvider:")]
		IntPtr Constructor(STPIssuingCardEphemeralKeyProvider keyProvider);

		// -(void)addPaymentPassViewController:(PKAddPaymentPassViewController * _Nonnull)controller generateRequestWithCertificateChain:(NSArray<NSData *> * _Nonnull)certificates nonce:(NSData * _Nonnull)nonce nonceSignature:(NSData * _Nonnull)nonceSignature completionHandler:(void (^ _Nonnull)(PKAddPaymentPassRequest * _Nonnull))handler;
		[Export("addPaymentPassViewController:generateRequestWithCertificateChain:nonce:nonceSignature:completionHandler:")]
		void AddPaymentPassViewController(PKAddPaymentPassViewController controller, NSData[] certificates, NSData nonce, NSData nonceSignature, Action<PKAddPaymentPassRequest> handler);
	}

	// @interface STPPushProvisioningDetailsParams : NSObject
	[BaseType(typeof(NSObject))]
	interface STPPushProvisioningDetailsParams
	{
		// @property (readonly, nonatomic) NSString * _Nonnull cardId;
		[Export("cardId")]
		string CardId { get; }

		// @property (readonly, nonatomic) NSArray<NSData *> * _Nonnull certificates;
		[Export("certificates")]
		NSData[] Certificates { get; }

		// @property (readonly, nonatomic) NSData * _Nonnull nonce;
		[Export("nonce")]
		NSData Nonce { get; }

		// @property (readonly, nonatomic) NSData * _Nonnull nonceSignature;
		[Export("nonceSignature")]
		NSData NonceSignature { get; }

		// @property (readonly, nonatomic) NSArray<NSString *> * _Nonnull certificatesBase64;
		[Export("certificatesBase64")]
		string[] CertificatesBase64 { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull nonceHex;
		[Export("nonceHex")]
		string NonceHex { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull nonceSignatureHex;
		[Export("nonceSignatureHex")]
		string NonceSignatureHex { get; }

		// +(instancetype _Nonnull)paramsWithCardId:(NSString * _Nonnull)cardId certificates:(NSArray<NSData *> * _Nonnull)certificates nonce:(NSData * _Nonnull)nonce nonceSignature:(NSData * _Nonnull)nonceSignature;
		[Static]
		[Export("paramsWithCardId:certificates:nonce:nonceSignature:")]
		STPPushProvisioningDetailsParams ParamsWithCardId(string cardId, NSData[] certificates, NSData nonce, NSData nonceSignature);
	}

	// typedef void (^STPRedirectContextSourceCompletionBlock)(NSString * _Nonnull, NSString * _Nullable, NSError * _Nullable);
	delegate void STPRedirectContextSourceCompletionBlock(string arg0, [NullAllowed] string arg1, [NullAllowed] NSError arg2);

	// typedef STPRedirectContextSourceCompletionBlock STPRedirectContextCompletionBlock;
	delegate void STPRedirectContextCompletionBlock(string arg0, [NullAllowed] string arg1, [NullAllowed] NSError arg2);

	// typedef void (^STPRedirectContextPaymentIntentCompletionBlock)(NSString * _Nonnull, NSError * _Nullable);
	delegate void STPRedirectContextPaymentIntentCompletionBlock(string arg0, [NullAllowed] NSError arg1);

	// @interface STPRedirectContext : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface STPRedirectContext
	{
		// @property (readonly, nonatomic) STPRedirectContextState state;
		[Export("state")]
		STPRedirectContextState State { get; }

		// -(instancetype _Nullable)initWithSource:(STPSource * _Nonnull)source completion:(STPRedirectContextSourceCompletionBlock _Nonnull)completion;
		[Export("initWithSource:completion:")]
		IntPtr Constructor(STPSource source, STPRedirectContextSourceCompletionBlock completion);

		// -(instancetype _Nullable)initWithPaymentIntent:(STPPaymentIntent * _Nonnull)paymentIntent completion:(STPRedirectContextPaymentIntentCompletionBlock _Nonnull)completion;
		[Export("initWithPaymentIntent:completion:")]
		IntPtr Constructor(STPPaymentIntent paymentIntent, STPRedirectContextPaymentIntentCompletionBlock completion);

		// -(void)startRedirectFlowFromViewController:(UIViewController * _Nonnull)presentingViewController;
		[Export("startRedirectFlowFromViewController:")]
		void StartRedirectFlowFromViewController(UIViewController presentingViewController);

		// -(void)startSafariViewControllerRedirectFlowFromViewController:(UIViewController * _Nonnull)presentingViewController;
		[Export("startSafariViewControllerRedirectFlowFromViewController:")]
		void StartSafariViewControllerRedirectFlowFromViewController(UIViewController presentingViewController);

		// -(void)startSafariAppRedirectFlow;
		[Export("startSafariAppRedirectFlow")]
		void StartSafariAppRedirectFlow();

		// -(void)cancel;
		[Export("cancel")]
		void Cancel();
	}

	// @interface STPSetupIntent : NSObject <STPAPIResponseDecodable>
	[BaseType(typeof(NSObject))]
	interface STPSetupIntent
	{
		// @property (readonly, nonatomic) NSString * _Nonnull stripeID;
		[Export("stripeID")]
		string StripeID { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull clientSecret;
		[Export("clientSecret")]
		string ClientSecret { get; }

		// @property (readonly, nonatomic) NSDate * _Nonnull created;
		[Export("created")]
		NSDate Created { get; }

		// @property (readonly, nonatomic) NSString * _Nullable customerID;
		[NullAllowed, Export("customerID")]
		string CustomerID { get; }

		// @property (readonly, nonatomic) NSString * _Nullable stripeDescription;
		[NullAllowed, Export("stripeDescription")]
		string StripeDescription { get; }

		// @property (readonly, nonatomic) BOOL livemode;
		[Export("livemode")]
		bool Livemode { get; }

		// @property (readonly, nonatomic) STPIntentAction * _Nullable nextAction;
		[NullAllowed, Export("nextAction")]
		STPIntentAction NextAction { get; }

		// @property (readonly, nonatomic) NSString * _Nullable paymentMethodID;
		[NullAllowed, Export("paymentMethodID")]
		string PaymentMethodID { get; }

		// @property (readonly, nonatomic) NSArray<NSNumber *> * _Nonnull paymentMethodTypes;
		[Export("paymentMethodTypes")]
		NSNumber[] PaymentMethodTypes { get; }

		// @property (readonly, nonatomic) STPSetupIntentStatus status;
		[Export("status")]
		STPSetupIntentStatus Status { get; }

		// @property (readonly, nonatomic) STPSetupIntentUsage usage;
		[Export("usage")]
		STPSetupIntentUsage Usage { get; }

		// @property (readonly, nonatomic) STPSetupIntentLastSetupError * _Nullable lastSetupError;
		[NullAllowed, Export("lastSetupError")]
		STPSetupIntentLastSetupError LastSetupError { get; }

		// @property (readonly, nonatomic) DEPRECATED_MSG_ATTRIBUTE("Metadata is not longer to clients using publishable keys. Retrieve them on your server using yoursecret key instead.") NSDictionary<NSString *,NSString *> * metadata __attribute__((deprecated("Metadata is not longer to clients using publishable keys. Retrieve them on your server using yoursecret key instead.")));
		[Export("metadata")]
		NSDictionary<NSString, NSString> Metadata { get; }
	}

	// @interface STPSetupIntentConfirmParams : NSObject <NSCopying, STPFormEncodable>
	[BaseType(typeof(NSObject))]
	interface STPSetupIntentConfirmParams : INSCopying
	{
		// -(instancetype _Nonnull)initWithClientSecret:(NSString * _Nonnull)clientSecret;
		[Export("initWithClientSecret:")]
		IntPtr Constructor(string clientSecret);

		// @property (copy, nonatomic) NSString * _Nonnull clientSecret;
		[Export("clientSecret")]
		string ClientSecret { get; set; }

		// @property (nonatomic, strong) STPPaymentMethodParams * _Nullable paymentMethodParams;
		[NullAllowed, Export("paymentMethodParams", ArgumentSemantic.Strong)]
		STPPaymentMethodParams PaymentMethodParams { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable paymentMethodID;
		[NullAllowed, Export("paymentMethodID")]
		string PaymentMethodID { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable returnURL;
		[NullAllowed, Export("returnURL")]
		string ReturnURL { get; set; }

		// @property (nonatomic) NSNumber * _Nullable useStripeSDK;
		[NullAllowed, Export("useStripeSDK", ArgumentSemantic.Assign)]
		NSNumber UseStripeSDK { get; set; }

		// @property (nonatomic) STPMandateDataParams * _Nullable mandateData;
		[NullAllowed, Export("mandateData", ArgumentSemantic.Assign)]
		STPMandateDataParams MandateData { get; set; }

		// @property (nonatomic) NSString * _Nullable mandate;
		[NullAllowed, Export("mandate")]
		string Mandate { get; set; }
	}

	// @interface Utilities (STPSetupIntentConfirmParams)
	[Category]
	[BaseType(typeof(STPSetupIntentConfirmParams))]
	interface STPSetupIntentConfirmParams_Utilities
	{
		// +(BOOL)isClientSecretValid:(NSString * _Nonnull)clientSecret;
		[Static]
		[Export("isClientSecretValid:")]
		bool IsClientSecretValid(string clientSecret);
	}

	// @interface STPSetupIntentLastSetupError : NSObject <STPAPIResponseDecodable>
	[BaseType(typeof(NSObject))]
	interface STPSetupIntentLastSetupError
	{
		// @property (readonly, nonatomic) NSString * _Nullable code;
		[NullAllowed, Export("code")]
		string Code { get; }

		// @property (readonly, nonatomic) NSString * _Nullable declineCode;
		[NullAllowed, Export("declineCode")]
		string DeclineCode { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull docURL;
		[Export("docURL")]
		string DocURL { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull message;
		[Export("message")]
		string Message { get; }

		// @property (readonly, nonatomic) NSString * _Nullable param;
		[NullAllowed, Export("param")]
		string Param { get; }

		// @property (readonly, nonatomic) STPPaymentMethod * _Nullable paymentMethod;
		[NullAllowed, Export("paymentMethod")]
		STPPaymentMethod PaymentMethod { get; }

		// @property (readonly, nonatomic) STPSetupIntentLastSetupErrorType type;
		[Export("type")]
		STPSetupIntentLastSetupErrorType Type { get; }
	}

	// @interface STPShippingAddressViewController : STPCoreTableViewController
	[BaseType(typeof(STPCoreTableViewController))]
	interface STPShippingAddressViewController
	{
		// -(instancetype _Nonnull)initWithPaymentContext:(STPPaymentContext * _Nonnull)paymentContext;
		[Export("initWithPaymentContext:")]
		IntPtr Constructor(STPPaymentContext paymentContext);

		// -(instancetype _Nonnull)initWithConfiguration:(STPPaymentConfiguration * _Nonnull)configuration theme:(STPTheme * _Nonnull)theme currency:(NSString * _Nullable)currency shippingAddress:(STPAddress * _Nullable)shippingAddress selectedShippingMethod:(PKShippingMethod * _Nullable)selectedShippingMethod prefilledInformation:(STPUserInformation * _Nullable)prefilledInformation;
		[Export("initWithConfiguration:theme:currency:shippingAddress:selectedShippingMethod:prefilledInformation:")]
		IntPtr Constructor(STPPaymentConfiguration configuration, STPTheme theme, [NullAllowed] string currency, [NullAllowed] STPAddress shippingAddress, [NullAllowed] PKShippingMethod selectedShippingMethod, [NullAllowed] STPUserInformation prefilledInformation);

		[Wrap("WeakDelegate")]
		[NullAllowed]
		STPShippingAddressViewControllerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<STPShippingAddressViewControllerDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// -(void)dismissWithCompletion:(STPVoidBlock _Nullable)completion;
		[Export("dismissWithCompletion:")]
		void DismissWithCompletion([NullAllowed] STPVoidBlock completion);
	}

	// @protocol STPShippingAddressViewControllerDelegate <NSObject>
	[Protocol, Model(AutoGeneratedName = true)]
	[BaseType(typeof(NSObject))]
	interface STPShippingAddressViewControllerDelegate
	{
		// @required -(void)shippingAddressViewControllerDidCancel:(STPShippingAddressViewController * _Nonnull)addressViewController;
		[Abstract]
		[Export("shippingAddressViewControllerDidCancel:")]
		void ShippingAddressViewControllerDidCancel(STPShippingAddressViewController addressViewController);

		// @required -(void)shippingAddressViewController:(STPShippingAddressViewController * _Nonnull)addressViewController didEnterAddress:(STPAddress * _Nonnull)address completion:(STPShippingMethodsCompletionBlock _Nonnull)completion;
		[Abstract]
		[Export("shippingAddressViewController:didEnterAddress:completion:")]
		void ShippingAddressViewController(STPShippingAddressViewController addressViewController, STPAddress address, STPShippingMethodsCompletionBlock completion);

		// @required -(void)shippingAddressViewController:(STPShippingAddressViewController * _Nonnull)addressViewController didFinishWithAddress:(STPAddress * _Nonnull)address shippingMethod:(PKShippingMethod * _Nullable)method;
		[Abstract]
		[Export("shippingAddressViewController:didFinishWithAddress:shippingMethod:")]
		void ShippingAddressViewController(STPShippingAddressViewController addressViewController, STPAddress address, [NullAllowed] PKShippingMethod method);
	}

	// @interface STPSourceCardDetails : NSObject <STPAPIResponseDecodable>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface STPSourceCardDetails
	{
		// @property (readonly, nonatomic) NSString * _Nullable last4;
		[NullAllowed, Export("last4")]
		string Last4 { get; }

		// @property (readonly, nonatomic) NSUInteger expMonth;
		[Export("expMonth")]
		nuint ExpMonth { get; }

		// @property (readonly, nonatomic) NSUInteger expYear;
		[Export("expYear")]
		nuint ExpYear { get; }

		// @property (readonly, nonatomic) STPCardBrand brand;
		[Export("brand")]
		STPCardBrand Brand { get; }

		// @property (readonly, nonatomic) STPCardFundingType funding;
		[Export("funding")]
		STPCardFundingType Funding { get; }

		// @property (readonly, nonatomic) NSString * _Nullable country;
		[NullAllowed, Export("country")]
		string Country { get; }

		// @property (readonly, nonatomic) STPSourceCard3DSecureStatus threeDSecure;
		[Export("threeDSecure")]
		STPSourceCard3DSecureStatus ThreeDSecure { get; }

		// @property (readonly, nonatomic) BOOL isApplePayCard;
		[Export("isApplePayCard")]
		bool IsApplePayCard { get; }
	}

	// @interface STPSourceOwner : NSObject <STPAPIResponseDecodable>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface STPSourceOwner
	{
		// @property (readonly, nonatomic) STPAddress * _Nullable address;
		[NullAllowed, Export("address")]
		STPAddress Address { get; }

		// @property (readonly, nonatomic) NSString * _Nullable email;
		[NullAllowed, Export("email")]
		string Email { get; }

		// @property (readonly, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export("name")]
		string Name { get; }

		// @property (readonly, nonatomic) NSString * _Nullable phone;
		[NullAllowed, Export("phone")]
		string Phone { get; }

		// @property (readonly, nonatomic) STPAddress * _Nullable verifiedAddress;
		[NullAllowed, Export("verifiedAddress")]
		STPAddress VerifiedAddress { get; }

		// @property (readonly, nonatomic) NSString * _Nullable verifiedEmail;
		[NullAllowed, Export("verifiedEmail")]
		string VerifiedEmail { get; }

		// @property (readonly, nonatomic) NSString * _Nullable verifiedName;
		[NullAllowed, Export("verifiedName")]
		string VerifiedName { get; }

		// @property (readonly, nonatomic) NSString * _Nullable verifiedPhone;
		[NullAllowed, Export("verifiedPhone")]
		string VerifiedPhone { get; }
	}

	// @interface STPSourceReceiver : NSObject <STPAPIResponseDecodable>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface STPSourceReceiver
	{
		// @property (readonly, nonatomic) NSString * _Nullable address;
		[NullAllowed, Export("address")]
		string Address { get; }

		// @property (readonly, nonatomic) NSNumber * _Nullable amountCharged;
		[NullAllowed, Export("amountCharged")]
		NSNumber AmountCharged { get; }

		// @property (readonly, nonatomic) NSNumber * _Nullable amountReceived;
		[NullAllowed, Export("amountReceived")]
		NSNumber AmountReceived { get; }

		// @property (readonly, nonatomic) NSNumber * _Nullable amountReturned;
		[NullAllowed, Export("amountReturned")]
		NSNumber AmountReturned { get; }
	}

	// @interface STPSourceRedirect : NSObject <STPAPIResponseDecodable>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface STPSourceRedirect
	{
		// @property (readonly, nonatomic) NSURL * _Nullable returnURL;
		[NullAllowed, Export("returnURL")]
		NSUrl ReturnURL { get; }

		// @property (readonly, nonatomic) STPSourceRedirectStatus status;
		[Export("status")]
		STPSourceRedirectStatus Status { get; }

		// @property (readonly, nonatomic) NSURL * _Nullable url;
		[NullAllowed, Export("url")]
		NSUrl Url { get; }
	}

	// @interface STPSourceSEPADebitDetails : NSObject <STPAPIResponseDecodable>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface STPSourceSEPADebitDetails
	{
		// @property (readonly, nonatomic) NSString * _Nullable last4;
		[NullAllowed, Export("last4")]
		string Last4 { get; }

		// @property (readonly, nonatomic) NSString * _Nullable bankCode;
		[NullAllowed, Export("bankCode")]
		string BankCode { get; }

		// @property (readonly, nonatomic) NSString * _Nullable country;
		[NullAllowed, Export("country")]
		string Country { get; }

		// @property (readonly, nonatomic) NSString * _Nullable fingerprint;
		[NullAllowed, Export("fingerprint")]
		string Fingerprint { get; }

		// @property (readonly, nonatomic) NSString * _Nullable mandateReference;
		[NullAllowed, Export("mandateReference")]
		string MandateReference { get; }

		// @property (readonly, nonatomic) NSURL * _Nullable mandateURL;
		[NullAllowed, Export("mandateURL")]
		NSUrl MandateURL { get; }
	}

	// @interface STPSourceVerification : NSObject <STPAPIResponseDecodable>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface STPSourceVerification
	{
		// @property (readonly, nonatomic) NSNumber * _Nullable attemptsRemaining;
		[NullAllowed, Export("attemptsRemaining")]
		NSNumber AttemptsRemaining { get; }

		// @property (readonly, nonatomic) STPSourceVerificationStatus status;
		[Export("status")]
		STPSourceVerificationStatus Status { get; }
	}

	// @interface STPSource : NSObject <STPAPIResponseDecodable, STPSourceProtocol, STPPaymentOption>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface STPSource : STPSourceProtocol, STPPaymentOption
	{
		// @property (readonly, nonatomic) NSNumber * _Nullable amount;
		[NullAllowed, Export("amount")]
		NSNumber Amount { get; }

		// @property (readonly, nonatomic) NSString * _Nullable clientSecret;
		[NullAllowed, Export("clientSecret")]
		string ClientSecret { get; }

		// @property (readonly, nonatomic) NSDate * _Nullable created;
		[NullAllowed, Export("created")]
		NSDate Created { get; }

		// @property (readonly, nonatomic) NSString * _Nullable currency;
		[NullAllowed, Export("currency")]
		string Currency { get; }

		// @property (readonly, nonatomic) STPSourceFlow flow;
		[Export("flow")]
		STPSourceFlow Flow { get; }

		// @property (readonly, nonatomic) BOOL livemode;
		[Export("livemode")]
		bool Livemode { get; }

		// @property (readonly, nonatomic) STPSourceOwner * _Nullable owner;
		[NullAllowed, Export("owner")]
		STPSourceOwner Owner { get; }

		// @property (readonly, nonatomic) STPSourceReceiver * _Nullable receiver;
		[NullAllowed, Export("receiver")]
		STPSourceReceiver Receiver { get; }

		// @property (readonly, nonatomic) STPSourceRedirect * _Nullable redirect;
		[NullAllowed, Export("redirect")]
		STPSourceRedirect Redirect { get; }

		// @property (readonly, nonatomic) STPSourceStatus status;
		[Export("status")]
		STPSourceStatus Status { get; }

		// @property (readonly, nonatomic) STPSourceType type;
		[Export("type")]
		STPSourceType Type { get; }

		// @property (readonly, nonatomic) STPSourceUsage usage;
		[Export("usage")]
		STPSourceUsage Usage { get; }

		// @property (readonly, nonatomic) STPSourceVerification * _Nullable verification;
		[NullAllowed, Export("verification")]
		STPSourceVerification Verification { get; }

		// @property (readonly, nonatomic) NSDictionary * _Nullable details;
		[NullAllowed, Export("details")]
		NSDictionary Details { get; }

		// @property (readonly, nonatomic) STPSourceCardDetails * _Nullable cardDetails;
		[NullAllowed, Export("cardDetails")]
		STPSourceCardDetails CardDetails { get; }

		// @property (readonly, nonatomic) STPSourceKlarnaDetails * _Nullable klarnaDetails;
		[NullAllowed, Export("klarnaDetails")]
		STPSourceKlarnaDetails KlarnaDetails { get; }

		// @property (readonly, nonatomic) STPSourceSEPADebitDetails * _Nullable sepaDebitDetails;
		[NullAllowed, Export("sepaDebitDetails")]
		STPSourceSEPADebitDetails SepaDebitDetails { get; }

		// @property (readonly, nonatomic) STPSourceWeChatPayDetails * _Nullable weChatPayDetails;
		[NullAllowed, Export("weChatPayDetails")]
		STPSourceWeChatPayDetails WeChatPayDetails { get; }

		// @property (readonly, nonatomic) DEPRECATED_MSG_ATTRIBUTE("Metadata is no longer returned to clients using publishable keys. Retrieve them on your server using yoursecret key instead.") NSDictionary<NSString *,NSString *> * metadata __attribute__((deprecated("Metadata is no longer returned to clients using publishable keys. Retrieve them on your server using yoursecret key instead.")));
		[Export("metadata")]
		NSDictionary<NSString, NSString> Metadata { get; }
	}

	// @interface STPSourceKlarnaDetails : NSObject <STPAPIResponseDecodable>
	[BaseType(typeof(NSObject))]
	interface STPSourceKlarnaDetails
	{
		// @property (readonly, nonatomic) NSString * _Nonnull clientToken;
		[Export("clientToken")]
		string ClientToken { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull purchaseCountry;
		[Export("purchaseCountry")]
		string PurchaseCountry { get; }
	}

	// @interface STPSourceParams : NSObject <STPFormEncodable, NSCopying>
	[BaseType(typeof(NSObject))]
	interface STPSourceParams : INSCopying
	{
		// @property (assign, nonatomic) STPSourceType type;
		[Export("type", ArgumentSemantic.Assign)]
		STPSourceType Type { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable rawTypeString;
		[NullAllowed, Export("rawTypeString")]
		string RawTypeString { get; set; }

		// @property (copy, nonatomic) NSNumber * _Nullable amount;
		[NullAllowed, Export("amount", ArgumentSemantic.Copy)]
		NSNumber Amount { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable currency;
		[NullAllowed, Export("currency")]
		string Currency { get; set; }

		// @property (assign, nonatomic) STPSourceFlow flow;
		[Export("flow", ArgumentSemantic.Assign)]
		STPSourceFlow Flow { get; set; }

		// @property (copy, nonatomic) NSDictionary * _Nullable metadata;
		[NullAllowed, Export("metadata", ArgumentSemantic.Copy)]
		NSDictionary Metadata { get; set; }

		// @property (copy, nonatomic) NSDictionary * _Nullable owner;
		[NullAllowed, Export("owner", ArgumentSemantic.Copy)]
		NSDictionary Owner { get; set; }

		// @property (copy, nonatomic) NSDictionary * _Nullable redirect;
		[NullAllowed, Export("redirect", ArgumentSemantic.Copy)]
		NSDictionary Redirect { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable token;
		[NullAllowed, Export("token")]
		string Token { get; set; }

		// @property (assign, nonatomic) STPSourceUsage usage;
		[Export("usage", ArgumentSemantic.Assign)]
		STPSourceUsage Usage { get; set; }

		// +(STPSourceParams * _Nonnull)bancontactParamsWithAmount:(NSUInteger)amount name:(NSString * _Nonnull)name returnURL:(NSString * _Nonnull)returnURL statementDescriptor:(NSString * _Nullable)statementDescriptor;
		[Static]
		[Export("bancontactParamsWithAmount:name:returnURL:statementDescriptor:")]
		STPSourceParams BancontactParamsWithAmount(nuint amount, string name, string returnURL, [NullAllowed] string statementDescriptor);

		// +(STPSourceParams * _Nonnull)cardParamsWithCard:(STPCardParams * _Nonnull)card;
		[Static]
		[Export("cardParamsWithCard:")]
		STPSourceParams CardParamsWithCard(STPCardParams card);

		// +(STPSourceParams * _Nonnull)giropayParamsWithAmount:(NSUInteger)amount name:(NSString * _Nonnull)name returnURL:(NSString * _Nonnull)returnURL statementDescriptor:(NSString * _Nullable)statementDescriptor;
		[Static]
		[Export("giropayParamsWithAmount:name:returnURL:statementDescriptor:")]
		STPSourceParams GiropayParamsWithAmount(nuint amount, string name, string returnURL, [NullAllowed] string statementDescriptor);

		// +(STPSourceParams * _Nonnull)idealParamsWithAmount:(NSUInteger)amount name:(NSString * _Nullable)name returnURL:(NSString * _Nonnull)returnURL statementDescriptor:(NSString * _Nullable)statementDescriptor bank:(NSString * _Nullable)bank;
		[Static]
		[Export("idealParamsWithAmount:name:returnURL:statementDescriptor:bank:")]
		STPSourceParams IdealParamsWithAmount(nuint amount, [NullAllowed] string name, string returnURL, [NullAllowed] string statementDescriptor, [NullAllowed] string bank);

		// +(STPSourceParams * _Nonnull)sepaDebitParamsWithName:(NSString * _Nonnull)name iban:(NSString * _Nonnull)iban addressLine1:(NSString * _Nullable)addressLine1 city:(NSString * _Nullable)city postalCode:(NSString * _Nullable)postalCode country:(NSString * _Nullable)country;
		[Static]
		[Export("sepaDebitParamsWithName:iban:addressLine1:city:postalCode:country:")]
		STPSourceParams SepaDebitParamsWithName(string name, string iban, [NullAllowed] string addressLine1, [NullAllowed] string city, [NullAllowed] string postalCode, [NullAllowed] string country);

		// +(STPSourceParams * _Nonnull)sofortParamsWithAmount:(NSUInteger)amount returnURL:(NSString * _Nonnull)returnURL country:(NSString * _Nonnull)country statementDescriptor:(NSString * _Nullable)statementDescriptor;
		[Static]
		[Export("sofortParamsWithAmount:returnURL:country:statementDescriptor:")]
		STPSourceParams SofortParamsWithAmount(nuint amount, string returnURL, string country, [NullAllowed] string statementDescriptor);

		// +(STPSourceParams * _Nonnull)klarnaParamsWithReturnURL:(NSString * _Nonnull)returnURL currency:(NSString * _Nonnull)currency purchaseCountry:(NSString * _Nonnull)purchaseCountry items:(NSArray<STPKlarnaLineItem *> * _Nonnull)items customPaymentMethods:(STPKlarnaPaymentMethods)customPaymentMethods billingAddress:(STPAddress * _Nullable)address billingFirstName:(NSString * _Nullable)firstName billingLastName:(NSString * _Nullable)lastName billingDOB:(STPDateOfBirth * _Nullable)dateOfBirth;
		[Static]
		[Export("klarnaParamsWithReturnURL:currency:purchaseCountry:items:customPaymentMethods:billingAddress:billingFirstName:billingLastName:billingDOB:")]
		STPSourceParams KlarnaParamsWithReturnURL(string returnURL, string currency, string purchaseCountry, STPKlarnaLineItem[] items, STPKlarnaPaymentMethods customPaymentMethods, [NullAllowed] STPAddress address, [NullAllowed] string firstName, [NullAllowed] string lastName, [NullAllowed] STPDateOfBirth dateOfBirth);

		// +(STPSourceParams * _Nonnull)klarnaParamsWithReturnURL:(NSString * _Nonnull)returnURL currency:(NSString * _Nonnull)currency purchaseCountry:(NSString * _Nonnull)purchaseCountry items:(NSArray<STPKlarnaLineItem *> * _Nonnull)items customPaymentMethods:(STPKlarnaPaymentMethods)customPaymentMethods;
		[Static]
		[Export("klarnaParamsWithReturnURL:currency:purchaseCountry:items:customPaymentMethods:")]
		STPSourceParams KlarnaParamsWithReturnURL(string returnURL, string currency, string purchaseCountry, STPKlarnaLineItem[] items, STPKlarnaPaymentMethods customPaymentMethods);

		// +(STPSourceParams * _Nonnull)threeDSecureParamsWithAmount:(NSUInteger)amount currency:(NSString * _Nonnull)currency returnURL:(NSString * _Nonnull)returnURL card:(NSString * _Nonnull)card;
		[Static]
		[Export("threeDSecureParamsWithAmount:currency:returnURL:card:")]
		STPSourceParams ThreeDSecureParamsWithAmount(nuint amount, string currency, string returnURL, string card);

		// +(STPSourceParams * _Nonnull)alipayParamsWithAmount:(NSUInteger)amount currency:(NSString * _Nonnull)currency returnURL:(NSString * _Nonnull)returnURL;
		[Static]
		[Export("alipayParamsWithAmount:currency:returnURL:")]
		STPSourceParams AlipayParamsWithAmount(nuint amount, string currency, string returnURL);

		// +(STPSourceParams * _Nonnull)alipayReusableParamsWithCurrency:(NSString * _Nonnull)currency returnURL:(NSString * _Nonnull)returnURL;
		[Static]
		[Export("alipayReusableParamsWithCurrency:returnURL:")]
		STPSourceParams AlipayReusableParamsWithCurrency(string currency, string returnURL);

		// +(STPSourceParams * _Nonnull)p24ParamsWithAmount:(NSUInteger)amount currency:(NSString * _Nonnull)currency email:(NSString * _Nonnull)email name:(NSString * _Nullable)name returnURL:(NSString * _Nonnull)returnURL;
		[Static]
		[Export("p24ParamsWithAmount:currency:email:name:returnURL:")]
		STPSourceParams P24ParamsWithAmount(nuint amount, string currency, string email, [NullAllowed] string name, string returnURL);

		// +(STPSourceParams * _Nonnull)visaCheckoutParamsWithCallId:(NSString * _Nonnull)callId;
		[Static]
		[Export("visaCheckoutParamsWithCallId:")]
		STPSourceParams VisaCheckoutParamsWithCallId(string callId);

		// +(STPSourceParams * _Nonnull)masterpassParamsWithCartId:(NSString * _Nonnull)cartId transactionId:(NSString * _Nonnull)transactionId;
		[Static]
		[Export("masterpassParamsWithCartId:transactionId:")]
		STPSourceParams MasterpassParamsWithCartId(string cartId, string transactionId);

		// +(STPSourceParams * _Nonnull)epsParamsWithAmount:(NSUInteger)amount name:(NSString * _Nonnull)name returnURL:(NSString * _Nonnull)returnURL statementDescriptor:(NSString * _Nullable)statementDescriptor;
		[Static]
		[Export("epsParamsWithAmount:name:returnURL:statementDescriptor:")]
		STPSourceParams EpsParamsWithAmount(nuint amount, string name, string returnURL, [NullAllowed] string statementDescriptor);

		// +(STPSourceParams * _Nonnull)multibancoParamsWithAmount:(NSUInteger)amount returnURL:(NSString * _Nonnull)returnURL email:(NSString * _Nonnull)email;
		[Static]
		[Export("multibancoParamsWithAmount:returnURL:email:")]
		STPSourceParams MultibancoParamsWithAmount(nuint amount, string returnURL, string email);

		// +(STPSourceParams * _Nonnull)wechatPayParamsWithAmount:(NSUInteger)amount currency:(NSString * _Nonnull)currency appId:(NSString * _Nonnull)appId statementDescriptor:(NSString * _Nullable)statementDescriptor;
		[Static]
		[Export("wechatPayParamsWithAmount:currency:appId:statementDescriptor:")]
		STPSourceParams WechatPayParamsWithAmount(nuint amount, string currency, string appId, [NullAllowed] string statementDescriptor);
	}

	// @interface STPSourceWeChatPayDetails : NSObject <STPAPIResponseDecodable>
	[BaseType(typeof(NSObject))]
	interface STPSourceWeChatPayDetails
	{
		// @property (readonly, nonatomic) NSString * _Nonnull weChatAppURL;
		[Export("weChatAppURL")]
		string WeChatAppURL { get; }
	}

	// @interface STPThreeDSButtonCustomization : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface STPThreeDSButtonCustomization
	{
		// +(instancetype _Nonnull)defaultSettingsForButtonType:(STPThreeDSCustomizationButtonType)type;
		[Static]
		[Export("defaultSettingsForButtonType:")]
		STPThreeDSButtonCustomization DefaultSettingsForButtonType(STPThreeDSCustomizationButtonType type);

		// -(instancetype _Nonnull)initWithBackgroundColor:(UIColor * _Nonnull)backgroundColor cornerRadius:(CGFloat)cornerRadius;
		[Export("initWithBackgroundColor:cornerRadius:")]
		IntPtr Constructor(UIColor backgroundColor, nfloat cornerRadius);

		// @property (nonatomic, strong) UIColor * _Nonnull backgroundColor;
		[Export("backgroundColor", ArgumentSemantic.Strong)]
		UIColor BackgroundColor { get; set; }

		// @property (nonatomic) CGFloat cornerRadius;
		[Export("cornerRadius")]
		nfloat CornerRadius { get; set; }

		// @property (nonatomic) STPThreeDSButtonTitleStyle titleStyle;
		[Export("titleStyle", ArgumentSemantic.Assign)]
		STPThreeDSButtonTitleStyle TitleStyle { get; set; }

		// @property (nonatomic, strong) UIFont * _Nonnull font;
		[Export("font", ArgumentSemantic.Strong)]
		UIFont Font { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull textColor;
		[Export("textColor", ArgumentSemantic.Strong)]
		UIColor TextColor { get; set; }
	}

	// @interface STPThreeDSCustomizationSettings : NSObject
	[BaseType(typeof(NSObject))]
	interface STPThreeDSCustomizationSettings
	{
		// +(instancetype _Nonnull)defaultSettings;
		[Static]
		[Export("defaultSettings")]
		STPThreeDSCustomizationSettings DefaultSettings();

		// @property (nonatomic) STPThreeDSUICustomization * _Nonnull uiCustomization;
		[Export("uiCustomization", ArgumentSemantic.Assign)]
		STPThreeDSUICustomization UiCustomization { get; set; }

		// @property (nonatomic) NSInteger authenticationTimeout;
		[Export("authenticationTimeout")]
		nint AuthenticationTimeout { get; set; }
	}

	// @interface STPThreeDSFooterCustomization : NSObject
	[BaseType(typeof(NSObject))]
	interface STPThreeDSFooterCustomization
	{
		// +(instancetype _Nonnull)defaultSettings;
		[Static]
		[Export("defaultSettings")]
		STPThreeDSFooterCustomization DefaultSettings();

		// @property (nonatomic, strong) UIColor * _Nonnull backgroundColor;
		[Export("backgroundColor", ArgumentSemantic.Strong)]
		UIColor BackgroundColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull chevronColor;
		[Export("chevronColor", ArgumentSemantic.Strong)]
		UIColor ChevronColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull headingTextColor;
		[Export("headingTextColor", ArgumentSemantic.Strong)]
		UIColor HeadingTextColor { get; set; }

		// @property (nonatomic, strong) UIFont * _Nonnull headingFont;
		[Export("headingFont", ArgumentSemantic.Strong)]
		UIFont HeadingFont { get; set; }

		// @property (nonatomic, strong) UIFont * _Nonnull font;
		[Export("font", ArgumentSemantic.Strong)]
		UIFont Font { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull textColor;
		[Export("textColor", ArgumentSemantic.Strong)]
		UIColor TextColor { get; set; }
	}

	// @interface STPThreeDSLabelCustomization : NSObject
	[BaseType(typeof(NSObject))]
	interface STPThreeDSLabelCustomization
	{
		// +(instancetype _Nonnull)defaultSettings;
		[Static]
		[Export("defaultSettings")]
		STPThreeDSLabelCustomization DefaultSettings();

		// @property (nonatomic, strong) UIFont * _Nonnull headingFont;
		[Export("headingFont", ArgumentSemantic.Strong)]
		UIFont HeadingFont { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull headingTextColor;
		[Export("headingTextColor", ArgumentSemantic.Strong)]
		UIColor HeadingTextColor { get; set; }

		// @property (nonatomic, strong) UIFont * _Nonnull font;
		[Export("font", ArgumentSemantic.Strong)]
		UIFont Font { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull textColor;
		[Export("textColor", ArgumentSemantic.Strong)]
		UIColor TextColor { get; set; }
	}

	// @interface STPThreeDSNavigationBarCustomization : NSObject
	[BaseType(typeof(NSObject))]
	interface STPThreeDSNavigationBarCustomization
	{
		// +(instancetype _Nonnull)defaultSettings;
		[Static]
		[Export("defaultSettings")]
		STPThreeDSNavigationBarCustomization DefaultSettings();

		// @property (nonatomic) UIColor * _Nullable barTintColor;
		[NullAllowed, Export("barTintColor", ArgumentSemantic.Assign)]
		UIColor BarTintColor { get; set; }

		// @property (nonatomic) UIBarStyle barStyle;
		[Export("barStyle", ArgumentSemantic.Assign)]
		UIBarStyle BarStyle { get; set; }

		// @property (getter = isTranslucent, nonatomic) BOOL translucent;
		[Export("translucent")]
		bool Translucent { [Bind("isTranslucent")] get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull headerText;
		[Export("headerText")]
		string HeaderText { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull buttonText;
		[Export("buttonText")]
		string ButtonText { get; set; }

		// @property (nonatomic) UIFont * _Nullable font;
		[NullAllowed, Export("font", ArgumentSemantic.Assign)]
		UIFont Font { get; set; }

		// @property (nonatomic) UIColor * _Nullable textColor;
		[NullAllowed, Export("textColor", ArgumentSemantic.Assign)]
		UIColor TextColor { get; set; }
	}

	// @interface STPThreeDSSelectionCustomization : NSObject
	[BaseType(typeof(NSObject))]
	interface STPThreeDSSelectionCustomization
	{
		// +(instancetype _Nonnull)defaultSettings;
		[Static]
		[Export("defaultSettings")]
		STPThreeDSSelectionCustomization DefaultSettings();

		// @property (nonatomic) UIColor * _Nonnull primarySelectedColor;
		[Export("primarySelectedColor", ArgumentSemantic.Assign)]
		UIColor PrimarySelectedColor { get; set; }

		// @property (nonatomic) UIColor * _Nonnull secondarySelectedColor;
		[Export("secondarySelectedColor", ArgumentSemantic.Assign)]
		UIColor SecondarySelectedColor { get; set; }

		// @property (nonatomic) UIColor * _Nonnull unselectedBackgroundColor;
		[Export("unselectedBackgroundColor", ArgumentSemantic.Assign)]
		UIColor UnselectedBackgroundColor { get; set; }

		// @property (nonatomic) UIColor * _Nonnull unselectedBorderColor;
		[Export("unselectedBorderColor", ArgumentSemantic.Assign)]
		UIColor UnselectedBorderColor { get; set; }
	}

	// @interface STPThreeDSTextFieldCustomization : NSObject
	[BaseType(typeof(NSObject))]
	interface STPThreeDSTextFieldCustomization
	{
		// +(instancetype _Nonnull)defaultSettings;
		[Static]
		[Export("defaultSettings")]
		STPThreeDSTextFieldCustomization DefaultSettings();

		// @property (nonatomic) CGFloat borderWidth;
		[Export("borderWidth")]
		nfloat BorderWidth { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull borderColor;
		[Export("borderColor", ArgumentSemantic.Strong)]
		UIColor BorderColor { get; set; }

		// @property (nonatomic) CGFloat cornerRadius;
		[Export("cornerRadius")]
		nfloat CornerRadius { get; set; }

		// @property (nonatomic) UIKeyboardAppearance keyboardAppearance;
		[Export("keyboardAppearance", ArgumentSemantic.Assign)]
		UIKeyboardAppearance KeyboardAppearance { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull placeholderTextColor;
		[Export("placeholderTextColor", ArgumentSemantic.Strong)]
		UIColor PlaceholderTextColor { get; set; }

		// @property (nonatomic, strong) UIFont * _Nonnull font;
		[Export("font", ArgumentSemantic.Strong)]
		UIFont Font { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull textColor;
		[Export("textColor", ArgumentSemantic.Strong)]
		UIColor TextColor { get; set; }
	}

	// @interface STPThreeDSUICustomization : NSObject
	[BaseType(typeof(NSObject))]
	interface STPThreeDSUICustomization
	{
		// +(instancetype _Nonnull)defaultSettings;
		[Static]
		[Export("defaultSettings")]
		STPThreeDSUICustomization DefaultSettings();

		// @property (nonatomic, strong) STPThreeDSNavigationBarCustomization * _Nonnull navigationBarCustomization;
		[Export("navigationBarCustomization", ArgumentSemantic.Strong)]
		STPThreeDSNavigationBarCustomization NavigationBarCustomization { get; set; }

		// @property (nonatomic, strong) STPThreeDSLabelCustomization * _Nonnull labelCustomization;
		[Export("labelCustomization", ArgumentSemantic.Strong)]
		STPThreeDSLabelCustomization LabelCustomization { get; set; }

		// @property (nonatomic) STPThreeDSTextFieldCustomization * _Nonnull textFieldCustomization;
		[Export("textFieldCustomization", ArgumentSemantic.Assign)]
		STPThreeDSTextFieldCustomization TextFieldCustomization { get; set; }

		// @property (nonatomic) UIColor * _Nonnull backgroundColor;
		[Export("backgroundColor", ArgumentSemantic.Assign)]
		UIColor BackgroundColor { get; set; }

		// @property (nonatomic, strong) STPThreeDSFooterCustomization * _Nonnull footerCustomization;
		[Export("footerCustomization", ArgumentSemantic.Strong)]
		STPThreeDSFooterCustomization FooterCustomization { get; set; }

		// -(void)setButtonCustomization:(STPThreeDSButtonCustomization * _Nonnull)buttonCustomization forType:(STPThreeDSCustomizationButtonType)buttonType;
		[Export("setButtonCustomization:forType:")]
		void SetButtonCustomization(STPThreeDSButtonCustomization buttonCustomization, STPThreeDSCustomizationButtonType buttonType);

		// -(STPThreeDSButtonCustomization * _Nonnull)buttonCustomizationForButtonType:(STPThreeDSCustomizationButtonType)buttonType;
		[Export("buttonCustomizationForButtonType:")]
		STPThreeDSButtonCustomization ButtonCustomizationForButtonType(STPThreeDSCustomizationButtonType buttonType);

		// @property (nonatomic, strong) STPThreeDSSelectionCustomization * _Nonnull selectionCustomization;
		[Export("selectionCustomization", ArgumentSemantic.Strong)]
		STPThreeDSSelectionCustomization SelectionCustomization { get; set; }

		// @property (nonatomic) UIActivityIndicatorViewStyle activityIndicatorViewStyle;
		[Export("activityIndicatorViewStyle", ArgumentSemantic.Assign)]
		UIActivityIndicatorViewStyle ActivityIndicatorViewStyle { get; set; }

		// @property (nonatomic) UIBlurEffectStyle blurStyle;
		[Export("blurStyle", ArgumentSemantic.Assign)]
		UIBlurEffectStyle BlurStyle { get; set; }
	}

	// @interface STPToken : NSObject <STPAPIResponseDecodable, STPSourceProtocol>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface STPToken : STPSourceProtocol
	{
		// @property (readonly, nonatomic) NSString * _Nonnull tokenId;
		[Export("tokenId")]
		string TokenId { get; }

		// @property (readonly, nonatomic) BOOL livemode;
		[Export("livemode")]
		bool Livemode { get; }

		// @property (readonly, nonatomic) STPTokenType type;
		[Export("type")]
		STPTokenType Type { get; }

		// @property (readonly, nonatomic) STPCard * _Nullable card;
		[NullAllowed, Export("card")]
		STPCard Card { get; }

		// @property (readonly, nonatomic) STPBankAccount * _Nullable bankAccount;
		[NullAllowed, Export("bankAccount")]
		STPBankAccount BankAccount { get; }

		// @property (readonly, nonatomic) NSDate * _Nullable created;
		[NullAllowed, Export("created")]
		NSDate Created { get; }
	}

	// @interface Stripe (NSError)
	[Category]
	[BaseType(typeof(NSError))]
	interface NSError_Stripe
	{
		// +(NSError * _Nullable)stp_errorFromStripeResponse:(NSDictionary * _Nullable)jsonDictionary;
		[Static]
		[Export("stp_errorFromStripeResponse:")]
		[return: NullAllowed]
		NSError Stp_errorFromStripeResponse([NullAllowed] NSDictionary jsonDictionary);
	}


	// @interface STDSConfigParameters : NSObject
	[BaseType(typeof(NSObject))]
	interface STDSConfigParameters
	{
		// -(void)addParameterNamed:(NSString * _Nonnull)paramName withValue:(NSString * _Nonnull)paramValue toGroup:(NSString * _Nullable)paramGroup;
		[Export("addParameterNamed:withValue:toGroup:")]
		void AddParameterNamed(string paramName, string paramValue, [NullAllowed] string paramGroup);

		// -(void)addParameterNamed:(NSString * _Nonnull)paramName withValue:(NSString * _Nonnull)paramValue;
		[Export("addParameterNamed:withValue:")]
		void AddParameterNamed(string paramName, string paramValue);

		// -(NSString * _Nullable)parameterValue:(NSString * _Nonnull)paramName inGroup:(NSString * _Nullable)paramGroup;
		[Export("parameterValue:inGroup:")]
		[return: NullAllowed]
		string ParameterValue(string paramName, [NullAllowed] string paramGroup);

		// -(NSString * _Nullable)parameterValue:(NSString * _Nonnull)paramName;
		[Export("parameterValue:")]
		[return: NullAllowed]
		string ParameterValue(string paramName);

		// -(NSString * _Nullable)removeParameterNamed:(NSString * _Nonnull)paramName fromGroup:(NSString * _Nullable)paramGroup;
		[Export("removeParameterNamed:fromGroup:")]
		[return: NullAllowed]
		string RemoveParameterNamed(string paramName, [NullAllowed] string paramGroup);

		// -(NSString * _Nullable)removeParameterNamed:(NSString * _Nonnull)paramName;
		[Export("removeParameterNamed:")]
		[return: NullAllowed]
		string RemoveParameterNamed(string paramName);
	}

	// @interface STDSThreeDS2Service : NSObject
	[BaseType(typeof(NSObject))]
	interface STDSThreeDS2Service
	{
		// @property (readonly, nonatomic) NSArray<STDSWarning *> * _Nullable warnings;
		[NullAllowed, Export("warnings")]
		STDSWarning[] Warnings { get; }

		// -(void)initializeWithConfig:(STDSConfigParameters * _Nonnull)config locale:(NSLocale * _Nullable)locale uiSettings:(STDSUICustomization * _Nullable)uiSettings;
		[Export("initializeWithConfig:locale:uiSettings:")]
		void InitializeWithConfig(STDSConfigParameters config, [NullAllowed] NSLocale locale, [NullAllowed] STDSUICustomization uiSettings);

		// -(STDSTransaction * _Nonnull)createTransactionForDirectoryServer:(NSString * _Nonnull)directoryServerID withProtocolVersion:(NSString * _Nullable)protocolVersion;
		[Export("createTransactionForDirectoryServer:withProtocolVersion:")]
		STDSTransaction CreateTransactionForDirectoryServer(string directoryServerID, [NullAllowed] string protocolVersion);

		// -(STDSTransaction * _Nullable)createTransactionForDirectoryServer:(NSString * _Nonnull)directoryServerID serverKeyID:(NSString * _Nullable)serverKeyID certificateString:(NSString * _Nonnull)certificateString rootCertificateStrings:(NSArray<NSString *> * _Nonnull)rootCertificateStrings withProtocolVersion:(NSString * _Nullable)protocolVersion;
		[Export("createTransactionForDirectoryServer:serverKeyID:certificateString:rootCertificateStrings:withProtocolVersion:")]
		[return: NullAllowed]
		STDSTransaction CreateTransactionForDirectoryServer(string directoryServerID, [NullAllowed] string serverKeyID, string certificateString, string[] rootCertificateStrings, [NullAllowed] string protocolVersion);
	}

	// @interface STDSCustomization : NSObject <NSCopying>
	[BaseType(typeof(NSObject))]
	[Protocol]
	interface STDSCustomization : INSCopying
	{
		// @property (nonatomic) UIFont * _Nullable font;
		[NullAllowed, Export("font", ArgumentSemantic.Assign)]
		UIFont Font { get; set; }

		// @property (nonatomic) UIColor * _Nullable textColor;
		[NullAllowed, Export("textColor", ArgumentSemantic.Assign)]
		UIColor TextColor { get; set; }
	}

	// @interface STDSButtonCustomization : STDSCustomization
	[BaseType(typeof(STDSCustomization))]
	[DisableDefaultCtor]
	interface STDSButtonCustomization
	{
		// +(instancetype _Nonnull)defaultSettingsForButtonType:(STDSUICustomizationButtonType)type;
		[Static]
		[Export("defaultSettingsForButtonType:")]
		STDSButtonCustomization DefaultSettingsForButtonType(STDSUICustomizationButtonType type);

		// -(instancetype _Nonnull)initWithBackgroundColor:(UIColor * _Nonnull)backgroundColor cornerRadius:(CGFloat)cornerRadius;
		[Export("initWithBackgroundColor:cornerRadius:")]
		IntPtr Constructor(UIColor backgroundColor, nfloat cornerRadius);

		// @property (nonatomic) UIColor * _Nonnull backgroundColor;
		[Export("backgroundColor", ArgumentSemantic.Assign)]
		UIColor BackgroundColor { get; set; }

		// @property (nonatomic) CGFloat cornerRadius;
		[Export("cornerRadius")]
		nfloat CornerRadius { get; set; }

		// @property (nonatomic) STDSButtonTitleStyle titleStyle;
		[Export("titleStyle", ArgumentSemantic.Assign)]
		STDSButtonTitleStyle TitleStyle { get; set; }
	}

	// @interface STDSNavigationBarCustomization : STDSCustomization
	[BaseType(typeof(STDSCustomization))]
	interface STDSNavigationBarCustomization
	{
		// +(instancetype _Nonnull)defaultSettings;
		[Static]
		[Export("defaultSettings")]
		STDSNavigationBarCustomization DefaultSettings();

		// @property (nonatomic) UIColor * _Nullable barTintColor;
		[NullAllowed, Export("barTintColor", ArgumentSemantic.Assign)]
		UIColor BarTintColor { get; set; }

		// @property (nonatomic) UIBarStyle barStyle;
		[Export("barStyle", ArgumentSemantic.Assign)]
		UIBarStyle BarStyle { get; set; }

		// @property (nonatomic) BOOL translucent;
		[Export("translucent")]
		bool Translucent { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull headerText;
		[Export("headerText")]
		string HeaderText { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull buttonText;
		[Export("buttonText")]
		string ButtonText { get; set; }
	}

	// @interface STDSLabelCustomization : STDSCustomization
	[BaseType(typeof(STDSCustomization))]
	interface STDSLabelCustomization
	{
		// +(instancetype _Nonnull)defaultSettings;
		[Static]
		[Export("defaultSettings")]
		STDSLabelCustomization DefaultSettings();

		// @property (nonatomic) UIColor * _Nonnull headingTextColor;
		[Export("headingTextColor", ArgumentSemantic.Assign)]
		UIColor HeadingTextColor { get; set; }

		// @property (nonatomic) UIFont * _Nonnull headingFont;
		[Export("headingFont", ArgumentSemantic.Assign)]
		UIFont HeadingFont { get; set; }
	}

	// @interface STDSTextFieldCustomization : STDSCustomization
	[BaseType(typeof(STDSCustomization))]
	interface STDSTextFieldCustomization
	{
		// +(instancetype _Nonnull)defaultSettings;
		[Static]
		[Export("defaultSettings")]
		STDSTextFieldCustomization DefaultSettings();

		// @property (nonatomic) CGFloat borderWidth;
		[Export("borderWidth")]
		nfloat BorderWidth { get; set; }

		// @property (nonatomic) UIColor * _Nonnull borderColor;
		[Export("borderColor", ArgumentSemantic.Assign)]
		UIColor BorderColor { get; set; }

		// @property (nonatomic) CGFloat cornerRadius;
		[Export("cornerRadius")]
		nfloat CornerRadius { get; set; }

		// @property (nonatomic) UIKeyboardAppearance keyboardAppearance;
		[Export("keyboardAppearance", ArgumentSemantic.Assign)]
		UIKeyboardAppearance KeyboardAppearance { get; set; }

		// @property (nonatomic) UIColor * _Nonnull placeholderTextColor;
		[Export("placeholderTextColor", ArgumentSemantic.Assign)]
		UIColor PlaceholderTextColor { get; set; }
	}

	// @interface STDSFooterCustomization : STDSCustomization
	[BaseType(typeof(STDSCustomization))]
	interface STDSFooterCustomization
	{
		// +(instancetype _Nonnull)defaultSettings;
		[Static]
		[Export("defaultSettings")]
		STDSFooterCustomization DefaultSettings();

		// @property (nonatomic) UIColor * _Nonnull backgroundColor;
		[Export("backgroundColor", ArgumentSemantic.Assign)]
		UIColor BackgroundColor { get; set; }

		// @property (nonatomic) UIColor * _Nonnull chevronColor;
		[Export("chevronColor", ArgumentSemantic.Assign)]
		UIColor ChevronColor { get; set; }

		// @property (nonatomic) UIColor * _Nonnull headingTextColor;
		[Export("headingTextColor", ArgumentSemantic.Assign)]
		UIColor HeadingTextColor { get; set; }

		// @property (nonatomic) UIFont * _Nonnull headingFont;
		[Export("headingFont", ArgumentSemantic.Assign)]
		UIFont HeadingFont { get; set; }
	}

	// @interface STDSSelectionCustomization : NSObject <NSCopying>
	[BaseType(typeof(NSObject))]
	interface STDSSelectionCustomization : INSCopying
	{
		// +(instancetype _Nonnull)defaultSettings;
		[Static]
		[Export("defaultSettings")]
		STDSSelectionCustomization DefaultSettings();

		// @property (nonatomic) UIColor * _Nonnull primarySelectedColor;
		[Export("primarySelectedColor", ArgumentSemantic.Assign)]
		UIColor PrimarySelectedColor { get; set; }

		// @property (nonatomic) UIColor * _Nonnull secondarySelectedColor;
		[Export("secondarySelectedColor", ArgumentSemantic.Assign)]
		UIColor SecondarySelectedColor { get; set; }

		// @property (nonatomic) UIColor * _Nonnull unselectedBackgroundColor;
		[Export("unselectedBackgroundColor", ArgumentSemantic.Assign)]
		UIColor UnselectedBackgroundColor { get; set; }

		// @property (nonatomic) UIColor * _Nonnull unselectedBorderColor;
		[Export("unselectedBorderColor", ArgumentSemantic.Assign)]
		UIColor UnselectedBorderColor { get; set; }
	}

	// @interface STDSUICustomization : NSObject <NSCopying>
	[BaseType(typeof(NSObject))]
	interface STDSUICustomization : INSCopying
	{
		// +(instancetype _Nonnull)defaultSettings;
		[Static]
		[Export("defaultSettings")]
		STDSUICustomization DefaultSettings();

		// @property (nonatomic) STDSNavigationBarCustomization * _Nonnull navigationBarCustomization;
		[Export("navigationBarCustomization", ArgumentSemantic.Assign)]
		STDSNavigationBarCustomization NavigationBarCustomization { get; set; }

		// @property (nonatomic) STDSLabelCustomization * _Nonnull labelCustomization;
		[Export("labelCustomization", ArgumentSemantic.Assign)]
		STDSLabelCustomization LabelCustomization { get; set; }

		// @property (nonatomic) STDSTextFieldCustomization * _Nonnull textFieldCustomization;
		[Export("textFieldCustomization", ArgumentSemantic.Assign)]
		STDSTextFieldCustomization TextFieldCustomization { get; set; }

		// @property (nonatomic) UIColor * _Nonnull backgroundColor;
		[Export("backgroundColor", ArgumentSemantic.Assign)]
		UIColor BackgroundColor { get; set; }

		// @property (nonatomic) STDSFooterCustomization * _Nonnull footerCustomization;
		[Export("footerCustomization", ArgumentSemantic.Assign)]
		STDSFooterCustomization FooterCustomization { get; set; }

		// -(void)setButtonCustomization:(STDSButtonCustomization * _Nonnull)buttonCustomization forType:(STDSUICustomizationButtonType)buttonType;
		[Export("setButtonCustomization:forType:")]
		void SetButtonCustomization(STDSButtonCustomization buttonCustomization, STDSUICustomizationButtonType buttonType);

		// -(STDSButtonCustomization * _Nonnull)buttonCustomizationForButtonType:(STDSUICustomizationButtonType)buttonType;
		[Export("buttonCustomizationForButtonType:")]
		STDSButtonCustomization ButtonCustomizationForButtonType(STDSUICustomizationButtonType buttonType);

		// @property (nonatomic) STDSSelectionCustomization * _Nonnull selectionCustomization;
		[Export("selectionCustomization", ArgumentSemantic.Assign)]
		STDSSelectionCustomization SelectionCustomization { get; set; }

		// @property (nonatomic) UIStatusBarStyle preferredStatusBarStyle;
		[Export("preferredStatusBarStyle", ArgumentSemantic.Assign)]
		UIStatusBarStyle PreferredStatusBarStyle { get; set; }

		// @property (nonatomic) UIActivityIndicatorViewStyle activityIndicatorViewStyle;
		[Export("activityIndicatorViewStyle", ArgumentSemantic.Assign)]
		UIActivityIndicatorViewStyle ActivityIndicatorViewStyle { get; set; }

		// @property (nonatomic) UIBlurEffectStyle blurStyle;
		[Export("blurStyle", ArgumentSemantic.Assign)]
		UIBlurEffectStyle BlurStyle { get; set; }
	}

	// @interface STDSWarning : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	[Protocol]
	interface STDSWarning
	{
		// -(instancetype _Nonnull)initWithIdentifier:(NSString * _Nonnull)identifier message:(NSString * _Nonnull)message severity:(STDSWarningSeverity)severity __attribute__((objc_designated_initializer));
		[Export("initWithIdentifier:message:severity:")]
		[DesignatedInitializer]
		IntPtr Constructor(string identifier, string message, STDSWarningSeverity severity);

		// @property (readonly, nonatomic) NSString * _Nonnull identifier;
		[Export("identifier")]
		string Identifier { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull message;
		[Export("message")]
		string Message { get; }

		// @property (readonly, nonatomic) STDSWarningSeverity severity;
		[Export("severity")]
		STDSWarningSeverity Severity { get; }
	}

	// @interface STDSException : NSException
	[BaseType(typeof(NSException))]
	[Protocol]
	interface STDSException
	{
		// @property (readonly, nonatomic) NSString * _Nonnull message;
		[Export("message")]
		string Message { get; }
	}

	// @interface STDSAlreadyInitializedException : STDSException
	[BaseType(typeof(STDSException))]
	[Protocol]
	interface STDSAlreadyInitializedException
	{
	}

	// @interface STDSInvalidInputException : STDSException
	[BaseType(typeof(STDSException))]
	[Protocol]
	interface STDSInvalidInputException
	{
	}

	// @interface STDSNotInitializedException : STDSException
	[BaseType(typeof(STDSException))]
	[Protocol]
	interface STDSNotInitializedException
	{
	}

	// @interface STDSRuntimeException : STDSException
	[BaseType(typeof(STDSException))]
	[Protocol]
	interface STDSRuntimeException
	{
	}

	// @protocol STDSJSONEncodable <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol]
	[BaseType(typeof(NSObject))]
	interface STDSJSONEncodable
	{
		// @required +(NSDictionary * _Nonnull)propertyNamesToJSONKeysMapping;
		[Static, Abstract]
		[Export("propertyNamesToJSONKeysMapping")]
		NSDictionary PropertyNamesToJSONKeysMapping { get; }
	}

	// @protocol STDSJSONDecodable <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol]
	[BaseType(typeof(NSObject))]
	interface STDSJSONDecodable
	{
		// @required +(instancetype _Nullable)decodedObjectFromJSON:(NSDictionary * _Nullable)json error:(NSError * _Nullable * _Nullable)outError;
		[Abstract]
		[Export("decodedObjectFromJSON:error:")]
		[return: NullAllowed]
		STDSJSONDecodable Error([NullAllowed] NSDictionary json, [NullAllowed] out NSError outError);
	}

	// @interface STDSErrorMessage : NSObject <STDSJSONEncodable, STDSJSONDecodable>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	[Protocol]
	interface STDSErrorMessage : STDSJSONEncodable, STDSJSONDecodable
	{
		// -(instancetype _Nonnull)initWithErrorCode:(NSString * _Nonnull)errorCode errorComponent:(NSString * _Nonnull)errorComponent errorDescription:(NSString * _Nonnull)errorDescription errorDetails:(NSString * _Nullable)errorDetails messageVersion:(NSString * _Nonnull)messageVersion acsTransactionIdentifier:(NSString * _Nullable)acsTransactionIdentifier errorMessageType:(NSString * _Nonnull)errorMessageType;
		[Export("initWithErrorCode:errorComponent:errorDescription:errorDetails:messageVersion:acsTransactionIdentifier:errorMessageType:")]
		IntPtr Constructor(string errorCode, string errorComponent, string errorDescription, [NullAllowed] string errorDetails, string messageVersion, [NullAllowed] string acsTransactionIdentifier, string errorMessageType);

		// @property (readonly, nonatomic) NSString * _Nonnull errorCode;
		[Export("errorCode")]
		string ErrorCode { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull errorComponent;
		[Export("errorComponent")]
		string ErrorComponent { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull errorDescription;
		[Export("errorDescription")]
		string ErrorDescription { get; }

		// @property (readonly, nonatomic) NSString * _Nullable errorDetails;
		[NullAllowed, Export("errorDetails")]
		string ErrorDetails { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull messageVersion;
		[Export("messageVersion")]
		string MessageVersion { get; }

		// @property (readonly, nonatomic) NSString * _Nullable acsTransactionIdentifier;
		[NullAllowed, Export("acsTransactionIdentifier")]
		string AcsTransactionIdentifier { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull errorMessageType;
		[Export("errorMessageType")]
		string ErrorMessageType { get; }

		// -(NSError * _Nonnull)NSErrorValue;
		[Export("NSErrorValue")]
		NSError NSErrorValue { get; }
	}

	// @interface STDSProtocolErrorEvent : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	[Protocol]
	interface STDSProtocolErrorEvent
	{
		// -(instancetype _Nonnull)initWithSDKTransactionIdentifier:(NSString * _Nonnull)identifier errorMessage:(STDSErrorMessage * _Nonnull)errorMessage;
		[Export("initWithSDKTransactionIdentifier:errorMessage:")]
		IntPtr Constructor(string identifier, STDSErrorMessage errorMessage);

		// @property (readonly, nonatomic) STDSErrorMessage * _Nonnull errorMessage;
		[Export("errorMessage")]
		STDSErrorMessage ErrorMessage { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull sdkTransactionIdentifier;
		[Export("sdkTransactionIdentifier")]
		string SdkTransactionIdentifier { get; }
	}

	// @interface STDSRuntimeErrorEvent : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	[Protocol]
	interface STDSRuntimeErrorEvent
	{
		// @property (readonly, nonatomic) NSString * _Nonnull errorCode;
		[Export("errorCode")]
		string ErrorCode { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull errorMessage;
		[Export("errorMessage")]
		string ErrorMessage { get; }

		// -(instancetype _Nonnull)initWithErrorCode:(NSString * _Nonnull)errorCode errorMessage:(NSString * _Nonnull)errorMessage __attribute__((objc_designated_initializer));
		[Export("initWithErrorCode:errorMessage:")]
		[DesignatedInitializer]
		IntPtr Constructor(string errorCode, string errorMessage);

		// -(NSError * _Nonnull)NSErrorValue;
		[Export("NSErrorValue")]
		NSError NSErrorValue { get; }
	}

	// @interface STDSAuthenticationRequestParameters : NSObject <STDSJSONEncodable>
	[BaseType(typeof(NSObject))]
	[Protocol]
	interface STDSAuthenticationRequestParameters : STDSJSONEncodable
	{
		// -(instancetype _Nonnull)initWithSDKTransactionIdentifier:(NSString * _Nonnull)sdkTransactionIdentifier deviceData:(NSString * _Nullable)deviceData sdkEphemeralPublicKey:(NSString * _Nonnull)sdkEphemeralPublicKey sdkAppIdentifier:(NSString * _Nonnull)sdkAppIdentifier sdkReferenceNumber:(NSString * _Nonnull)sdkReferenceNumber messageVersion:(NSString * _Nonnull)messageVersion;
		[Export("initWithSDKTransactionIdentifier:deviceData:sdkEphemeralPublicKey:sdkAppIdentifier:sdkReferenceNumber:messageVersion:")]
		IntPtr Constructor(string sdkTransactionIdentifier, [NullAllowed] string deviceData, string sdkEphemeralPublicKey, string sdkAppIdentifier, string sdkReferenceNumber, string messageVersion);

		// @property (readonly, nonatomic) NSString * _Nullable deviceData;
		[NullAllowed, Export("deviceData")]
		string DeviceData { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull sdkTransactionIdentifier;
		[Export("sdkTransactionIdentifier")]
		string SdkTransactionIdentifier { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull sdkAppIdentifier;
		[Export("sdkAppIdentifier")]
		string SdkAppIdentifier { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull sdkReferenceNumber;
		[Export("sdkReferenceNumber")]
		string SdkReferenceNumber { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull sdkEphemeralPublicKey;
		[Export("sdkEphemeralPublicKey")]
		string SdkEphemeralPublicKey { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull messageVersion;
		[Export("messageVersion")]
		string MessageVersion { get; }
	}

	// @protocol STDSAuthenticationResponse <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol]
	[BaseType(typeof(NSObject))]
	interface STDSAuthenticationResponse
	{
		// @required @property (readonly, nonatomic) NSString * _Nonnull threeDSServerTransactionID;
		[Abstract]
		[Export("threeDSServerTransactionID")]
		string ThreeDSServerTransactionID { get; }

		// @required @property (readonly, nonatomic) STDSACSStatusType status;
		[Abstract]
		[Export("status")]
		STDSACSStatusType Status { get; }

		// @required @property (readonly, getter = isChallengeRequired, nonatomic) BOOL challengeRequired;
		[Abstract]
		[Export("challengeRequired")]
		bool ChallengeRequired { [Bind("isChallengeRequired")] get; }

		// @required @property (readonly, nonatomic) BOOL willUseDecoupledAuthentication;
		[Abstract]
		[Export("willUseDecoupledAuthentication")]
		bool WillUseDecoupledAuthentication { get; }

		// @required @property (readonly, nonatomic) NSString * _Nullable acsOperatorID;
		[Abstract]
		[NullAllowed, Export("acsOperatorID")]
		string AcsOperatorID { get; }

		// @required @property (readonly, nonatomic) NSString * _Nullable acsReferenceNumber;
		[Abstract]
		[NullAllowed, Export("acsReferenceNumber")]
		string AcsReferenceNumber { get; }

		// @required @property (readonly, nonatomic) NSString * _Nullable acsSignedContent;
		[Abstract]
		[NullAllowed, Export("acsSignedContent")]
		string AcsSignedContent { get; }

		// @required @property (readonly, nonatomic) NSString * _Nonnull acsTransactionID;
		[Abstract]
		[Export("acsTransactionID")]
		string AcsTransactionID { get; }

		// @required @property (readonly, nonatomic) NSURL * _Nullable acsURL;
		[Abstract]
		[NullAllowed, Export("acsURL")]
		NSUrl AcsURL { get; }

		// @required @property (readonly, nonatomic) NSString * _Nullable cardholderInfo;
		[Abstract]
		[NullAllowed, Export("cardholderInfo")]
		string CardholderInfo { get; }

		// @required @property (readonly, nonatomic) NSString * _Nullable directoryServerReferenceNumber;
		[Abstract]
		[NullAllowed, Export("directoryServerReferenceNumber")]
		string DirectoryServerReferenceNumber { get; }

		// @required @property (readonly, nonatomic) NSString * _Nullable directoryServerTransactionID;
		[Abstract]
		[NullAllowed, Export("directoryServerTransactionID")]
		string DirectoryServerTransactionID { get; }

		// @required @property (readonly, nonatomic) NSString * _Nonnull protocolVersion;
		[Abstract]
		[Export("protocolVersion")]
		string ProtocolVersion { get; }

		// @required @property (readonly, nonatomic) NSString * _Nonnull sdkTransactionID;
		[Abstract]
		[Export("sdkTransactionID")]
		string SdkTransactionID { get; }
	}

	// @interface STDSChallengeParameters : NSObject
	[BaseType(typeof(NSObject))]
	interface STDSChallengeParameters
	{
		// -(instancetype _Nonnull)initWithAuthenticationResponse:(id<STDSAuthenticationResponse> _Nonnull)authResponse;
		[Export("initWithAuthenticationResponse:")]
		IntPtr Constructor(STDSAuthenticationResponse authResponse);

		// @property (copy, nonatomic) NSString * _Nonnull threeDSServerTransactionID;
		[Export("threeDSServerTransactionID")]
		string ThreeDSServerTransactionID { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull acsTransactionID;
		[Export("acsTransactionID")]
		string AcsTransactionID { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull acsReferenceNumber;
		[Export("acsReferenceNumber")]
		string AcsReferenceNumber { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull acsSignedContent;
		[Export("acsSignedContent")]
		string AcsSignedContent { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable threeDSRequestorAppURL;
		[NullAllowed, Export("threeDSRequestorAppURL")]
		string ThreeDSRequestorAppURL { get; set; }
	}

	// @protocol STDSChallengeStatusReceiver <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol]
	[BaseType(typeof(NSObject))]
	interface STDSChallengeStatusReceiver
	{
		// @required -(void)transaction:(STDSTransaction * _Nonnull)transaction didCompleteChallengeWithCompletionEvent:(STDSCompletionEvent * _Nonnull)completionEvent;
		[Abstract]
		[Export("transaction:didCompleteChallengeWithCompletionEvent:")]
		void Transaction(STDSTransaction transaction, STDSCompletionEvent completionEvent);

		// @required -(void)transactionDidCancel:(STDSTransaction * _Nonnull)transaction;
		[Abstract]
		[Export("transactionDidCancel:")]
		void TransactionDidCancel(STDSTransaction transaction);

		// @required -(void)transactionDidTimeOut:(STDSTransaction * _Nonnull)transaction;
		[Abstract]
		[Export("transactionDidTimeOut:")]
		void TransactionDidTimeOut(STDSTransaction transaction);

		// @required -(void)transaction:(STDSTransaction * _Nonnull)transaction didErrorWithProtocolErrorEvent:(STDSProtocolErrorEvent * _Nonnull)protocolErrorEvent;
		[Abstract]
		[Export("transaction:didErrorWithProtocolErrorEvent:")]
		void Transaction(STDSTransaction transaction, STDSProtocolErrorEvent protocolErrorEvent);

		// @required -(void)transaction:(STDSTransaction * _Nonnull)transaction didErrorWithRuntimeErrorEvent:(STDSRuntimeErrorEvent * _Nonnull)runtimeErrorEvent;
		[Abstract]
		[Export("transaction:didErrorWithRuntimeErrorEvent:")]
		void Transaction(STDSTransaction transaction, STDSRuntimeErrorEvent runtimeErrorEvent);

		// @optional -(void)transactionDidPresentChallengeScreen:(STDSTransaction * _Nonnull)transaction;
		[Export("transactionDidPresentChallengeScreen:")]
		void TransactionDidPresentChallengeScreen(STDSTransaction transaction);
	}

	// @interface STDSCompletionEvent : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	[Protocol]
	interface STDSCompletionEvent
	{
		// -(instancetype _Nonnull)initWithSDKTransactionIdentifier:(NSString * _Nonnull)identifier transactionStatus:(NSString * _Nonnull)transactionStatus __attribute__((objc_designated_initializer));
		[Export("initWithSDKTransactionIdentifier:transactionStatus:")]
		[DesignatedInitializer]
		IntPtr Constructor(string identifier, string transactionStatus);

		// @property (readonly, nonatomic) NSString * _Nonnull sdkTransactionIdentifier;
		[Export("sdkTransactionIdentifier")]
		string SdkTransactionIdentifier { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull transactionStatus;
		[Export("transactionStatus")]
		string TransactionStatus { get; }
	}

	// @interface STDSJSONEncoder : NSObject
	[BaseType(typeof(NSObject))]
	interface STDSJSONEncoder
	{
		// +(NSDictionary * _Nonnull)dictionaryForObject:(NSObject<STDSJSONEncodable> * _Nonnull)object;
		[Static]
		[Export("dictionaryForObject:")]
		NSDictionary DictionaryForObject(STDSJSONEncodable @object);
	}

	// typedef void (^STDSTransactionVoidBlock)();
	delegate void STDSTransactionVoidBlock();

	// @interface STDSTransaction : NSObject
	[BaseType(typeof(NSObject))]
	[Protocol]
	interface STDSTransaction
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull presentedChallengeUIType;
		[Export("presentedChallengeUIType")]
		string PresentedChallengeUIType { get; }

		// -(STDSAuthenticationRequestParameters * _Nonnull)createAuthenticationRequestParameters;
		[Export("createAuthenticationRequestParameters")]
		STDSAuthenticationRequestParameters CreateAuthenticationRequestParameters { get; }

		// -(UIViewController * _Nonnull)createProgressViewControllerWithDidCancel:(STDSTransactionVoidBlock _Nonnull)didCancel;
		[Export("createProgressViewControllerWithDidCancel:")]
		UIViewController CreateProgressViewControllerWithDidCancel(STDSTransactionVoidBlock didCancel);

		// -(void)doChallengeWithViewController:(UIViewController * _Nonnull)presentingViewController challengeParameters:(STDSChallengeParameters * _Nonnull)challengeParameters challengeStatusReceiver:(id<STDSChallengeStatusReceiver> _Nonnull)challengeStatusReceiver timeout:(NSTimeInterval)timeout;
		[Export("doChallengeWithViewController:challengeParameters:challengeStatusReceiver:timeout:")]
		void DoChallengeWithViewController(UIViewController presentingViewController, STDSChallengeParameters challengeParameters, STDSChallengeStatusReceiver challengeStatusReceiver, double timeout);

		// -(NSString * _Nonnull)sdkVersion;
		[Export("sdkVersion")]
		string SdkVersion { get; }

		// -(void)close;
		[Export("close")]
		void Close();
	}
}
