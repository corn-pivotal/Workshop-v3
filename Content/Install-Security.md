# Installing Security Features

### Overview
The workshop application utilizes the internal UAC of PCF for user authorization and access. By default, this feature is disabled in the code to simplify deployments as admin access is required to complete the configuration. To complete configuration of UAC, the following steps will need to be completed to duplicate the security features found in the Steeltoe workshop. Existing users can be given access by adding the user to the security groups below.

- read.fortunes

`$ uaac member add read.fortunes {userid}`


#### Step 1: Setting up UAAC in Bash for Windows 10
To complete the setup of security for the application, the cf-uaac program needs to be used. For Windows users, this can present a challenge as the utility runs on Linux. Windows 10 users can install the bash shell to complete the configuration.

Installing cf-uaac using Ruby and Gem:

`$ sudo apt-add-repository ppa:brightbox/ruby-ng`

`$ sudo apt-get update`

`$ sudo apt install build-essential`

`$ sudo apt install ruby2.5-dev`

`$ sudo apt install ruby2.5`

`$ gem install cf-uaac`


#### Step 2: Configuring Application Security
To complete security configuration, use the cf-uaac command in the Linux shell to execute the following to enable the role "read.fortunes". You will need to have access to the UAA Admin Credentials to complete these tasks.

`$ uaac target uaa.sys.yourdomain.com --skip-ssl-validation`

`$ uaac token client get admin -s {admin password}`

`$ uaac group add read.fortunes`

`$ uaac user add {username} -p {password} --emails {email address}`

`$ uaac member add read.fortunes {username}`

`$ uaac client add myWorkshop --authorized_grant_types authorization_code,refresh_token --authorities uaa.resource --redirect_uri http://workshopui-*-*.apps.yourdomain.com/signin-cloudfoundry --autoapprove cloud_controller.read,cloud_controller_service_permissions.read,openid,read.fortunes --secret mySecret`

`$ uaac client update myWorkshop --scope read.fortunes,openid,cloud_controller.read,cloud_controller_service_permissions.read`
