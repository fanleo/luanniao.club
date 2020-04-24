>>Tips:this page use the google translate, if you found the **bug** you can push [PR](https://github.com/luanniao/luanniao.club/pulls) if you want.
# LuanNiao Blazor Component Library
LuanNiao Blazor component library is an ASP.NET Core Blazor component library developed ***based on*** the CSS style library of Antd V4 version.
The goal of our library is to create a convenient and fast component library for small and medium-sized enterprises based on Antd's high reuse style and high compatibility.
<p>
If you are interested in this, you can take a few minutes to read our introduction to determine if you decide to use / follow the current component library.
</p>

## Current project status
In the architectural design and early framework construction, there is no release plan. For Blazor from the landing to the actual project, we are still in the observation period, but this does not affect our realization of this component library, because Blazor gives us infinite imagination Space. <br/>
In addition, the actual use of our company requires not only this UI component library, but also a Canvas component. At present, you can already see examples in the Antd library, but it is really just a very simple example as you can see. Normally, we will start with Canvas2D to make the components we need.

## I hope to be able to thank the people who helped us here
These selfless and great people are:<br/>
[diwu0510](https://github.com/orgs/luanniao/people/diwu0510)<br/>
[lucio-c](https://github.com/orgs/luanniao/people/lucio-c)<br/>
[shenbo1](https://github.com/orgs/luanniao/people/shenbo1)<br/>
[talabright](https://github.com/orgs/luanniao/people/talabright) <br/>
We currently do not have too many contributors, but this will not affect our enthusiasm. We will improve this library as much as possible and accompany our company's project landing this component library. <br/>
If you are willing to waste your precious time on our humble project, your help will be my highest honor. <br/>
Well, don't disturb you, let me introduce you to our library!(•́⌄•́๑)૭✧
<br/>

### design concept
##### **Our component style is not limited to emulating Antd**
Therefore, you may find that our API may not be the same as Antd in your impression.


## Design background of the library
The warehouse is maintained by a complete enterprise team and some friends who are worthy of my respect.Each of our actions is actually used in our project, so we may not be the same as other libraries The implementation strategy will be affected by the following contents.If you cannot accept these contents, you may need to consider whether to continue to use the current component library.
1. This is a core issue: Blazor is currently in the Preview version. The purpose of making this library is to get our WASM development component library as soon as possible or as early as possible to deal with the problem of missing front-end personnel (***This is a sad Question***), so in the current situation, if we have not released the Release version of the Nuget package or our version does not have> 1.0.0.0, please do not use it in your production environment, our test must have failed . Similarly, if we have any new releases, we will update them on this website.
1. We do not guarantee that we will not destroy the original realization of ANTD
    For example, we directly split Menu into InlineMenu, DropdownMenu, HorizontalMenu, there will be other extensions in the future, but ANTD does not do this.
1. Our development route is not the actual application that will appear in real projects (yes, this may be more biased towards our projects, we are making internal applications in the enterprise).
    This may lead to ** We will implement*****but not immediately*** those features that are less common in the system.
    For example: the large calendar in ANTD, unfortunately, our product does not have a calendar-like function, so we don't consider investing in people to support it for the time being.
1. We may have a long period of component development **Pause**, yes, we are currently developing more components as soon as possible, but if you carefully read our submission record (too many, but I guarantee You will find that for a period of time, we have been modifying Blazor.Core, and component development has stalled, this is because we discovered a performance problem with Blazor (although it has been dealt with), but we are not It is guaranteed that this will not happen in the future. The reason is very simple, we need this component library to be used in our products, and it is impossible for our customers to accept **carton**.
### The reason we made these designs
You will find that our components are different from mainstream front-end frameworks such as react or vue in terms of use or design, for example:
1.  Our component properties are all capitalized,
     This is because we are based on Blazor, so we think from the design that you need to accept the code style of C #, and the code style of C # has a constraint **Property must start with a capital letter**.<br/>
You will see the following components:
    ```Html
      @("<Row Gutter=\"new MarginGutter() { Vertial = 10, Horizontal = 4 }\">")
      @("</Row>")
    ```
1.  We may ask you to pass very many subcomponents.<br/>
This is because, for now, Blazor cannot pass objects in properties. Of course, we know that you can write the following types of code
    ```C#
        @("RenderFragment _filedName=@\"<X></X>\"")
    ```
    However, after our actual testing, you can't fully use all combinations of such components, for example, you can't capture ***this*** instance, and it will produce some other strange problems, specifically you can Try to write your own code, the core problem is that you ca n’t capture the ***this*** instance. We also wrote the code in the first place, but later gave up, because in the current situation you are in actual work. It is necessary to capture ***this***.<br/>
So, we will have code similar to the following style
    ```Html
        @("<LNCard CStyle=\"width:300px\" Actions=\"new[]{ a1,a2,a3}\">")
        @("     <Title>")
        @("         Default size card")
        @("     </Title>")
        @("     <Extra>")
        @("         <a href=\"#\">More</a>")
        @("     </Extra>")
        @("     <ChildContent>")
        @("        <p>Card content</p>")
        @("        <p>Card content</p>")
        @("        <p>Card content</p>")
        @("     </ChildContent>")
        @("     <Actions>")
        @("         <CardAction>")
        @("             <LuanNiao.Blazor.Component.Antd.Button.LNButton OnClickCallback=\"@(async ( a)=>{ Console.WriteLine(\"asd\"); })\" />")
        @("         </CardAction>")
        @("         <CardAction>")
        @("             <EditOutlined />")
        @("         </CardAction>")
        @("         <CardAction>")
        @("             <EllipsisOutlined />")
        @("         </CardAction>")
        @("     </Actions>")
        @("</LNCard>")
    ```
1.  We currently have plans to make a status tree, but later ***canceled***, because we believe that there must be more powerful ** characters ** to achieve functions similar to ***Redux***, to At that time, we can take the ride by the way. After all, as strong as ANTD, this problem has not been considered. So we may not consider the ** state tree ** in the scope of functions in the near future.
1. For now, we will not consider adding **Web Rich Text Editor for the time being** If you need this feature, you may need to wait for a while. After our team has searched the entire network, we have not Find a **web rich text editor** suitable for Blazor.The current implementation is basically biased towards two extremes, as far as Markdown is concerned:
    1. Completely use C # to achieve all the content, but it is impossible to exist unless the markdown function similar to the C library is implemented, but this depends on a large number of server renderings, which violates the basic intention of WASM, assuming that I use the C library , From the perspective of WASM security, at this time we do not guarantee that all the .DLL, .SO libraries we generate can be applied on various platforms, and we may not have the means to get the current operation under any circumstances System platform information.
    1. MarkDown currently has more complete support for JavaScript / Type Script. Unfortunately, .NET supports only two cases: there are too many dependent components or the generated HTML cannot add rich extension components.
    1. What you currently see, or the Doc of the LuanNiao component library is written by Markdown, but we also paid a painful price, we can not support flow, because when we introduced flow, its dependent components and Blazor JS It caused a conflict, which made us have to give up Markdown support.

## About the problems we encountered when developing the component library
In the future, we will establish special areas in other places to share these contents, but as of now (April 24, 2020), there is no specific plan.
> You can follow the update of this website to determine whether we have made this update

<br/>
<br/>
<br/>
<br/>
<br/>
<br/>

# Thank you very much for reading here
Thank you for reading the current library, and we thank you for the few minutes wasted! You can enjoy it in our document library.

#### Small request
If there is a bug, I expect you to[GITHUB](https://github.com/luanniao/Blazor.Component.Antd)Submit an Issue to us on the previous page, your comments will give us great help!
