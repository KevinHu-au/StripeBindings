# StripeBindings

The iOS and Android Binding libraries for Stripe iOS/Android SDK. 

Stripe docs:
iOS Doc: https://stripe.dev/stripe-ios/docs/
iOS Github: https://github.com/stripe/stripe-ios
Android Doc: https://stripe.dev/stripe-android/stripe/
Android Github: https://github.com/stripe/stripe-android

For the Android library Binding, I did have quite a lot of issues initially which caused me quite a lot of times to fix. Especially the dependency of the library. Need carefully check the dependency from the source code Build.Gradle file 
https://github.com/stripe/stripe-android/blob/master/stripe/build.gradle. This library has dependency on Kotlinx, AndroidX, and com.stripe:stripe-3ds2-android.
     For Kotlinx, you will need install a nuget package https://www.nuget.org/packages/Karamunting.KotlinX.Coroutines.Android/ on your Android app project (not the binding library)
     For com.stripe:stripe-3ds2-android, which is a library for Stripe 3D Secure 2 (https://stripe.com/au/guides/3d-secure-2) 
      you will need create another Android binding libary for Strile 3. I have included it in this repo. And again, the your Android app project need have the reference to this binding library (DLL or Nuget).
