#pragma checksum "C:\Users\BERNA\Desktop\Web_App\ItServiceApp\Areas\Admin\Views\Shared\Partials\_right-bar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cb57bdd4eef5c31fba3c7b5058476b08285ea483"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Shared_Partials__right_bar), @"mvc.1.0.view", @"/Areas/Admin/Views/Shared/Partials/_right-bar.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 2 "C:\Users\BERNA\Desktop\Web_App\ItServiceApp\Areas\Admin\Views\_ViewImports.cshtml"
using ItServiceApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\BERNA\Desktop\Web_App\ItServiceApp\Areas\Admin\Views\_ViewImports.cshtml"
using ItServiceApp.ViewModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cb57bdd4eef5c31fba3c7b5058476b08285ea483", @"/Areas/Admin/Views/Shared/Partials/_right-bar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aa5b49960c9119efc3cc05f828911e874541653c", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Shared_Partials__right_bar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin-assets/images/small/img-1.gif"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-block mx-auto my-4"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("180"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin-assets/images/widgets/project3.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("thumb-lg rounded-circle"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<!--  Modal content for the above example -->
<div class=""modal modal-rightbar fade"" tabindex=""-1"" role=""dialog"" aria-labelledby=""MetricaRightbar"" aria-hidden=""true"">
    <div class=""modal-dialog modal-lg"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title mt-0"" id=""MetricaRightbar"">Appearance</h5>
                <button type=""button"" class=""btn btn-sm btn-soft-primary btn-circle btn-square"" data-dismiss=""modal"" aria-hidden=""true""><i class=""mdi mdi-close""></i></button>
            </div>
            <div class=""modal-body"">
                <!-- Nav tabs -->
                <ul class=""nav nav-pills nav-justified mt-2 mb-4"" role=""tablist"">
                    <li class=""nav-item waves-effect waves-light"">
                        <a class=""nav-link active"" data-toggle=""tab"" href=""#ActivityTab"" role=""tab"">Activity</a>
                    </li>
                    <li class=""nav-item waves-effect waves-light"">
         ");
            WriteLiteral(@"               <a class=""nav-link"" data-toggle=""tab"" href=""#TasksTab"" role=""tab"">Tasks</a>
                    </li>
                    <li class=""nav-item waves-effect waves-light"">
                        <a class=""nav-link"" data-toggle=""tab"" href=""#SettingsTab"" role=""tab"">Settings</a>
                    </li>
                </ul>

                <!-- Tab panes -->
                <div class=""tab-content"">
                    <div class=""tab-pane active "" id=""ActivityTab"" role=""tabpanel"">
                        <div class=""bg-light mx-n3"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "cb57bdd4eef5c31fba3c7b5058476b08285ea4837130", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        </div>
                        <div class=""slimscroll scroll-rightbar"">
                            <div class=""activity"">
                                <div class=""activity-info"">
                                    <div class=""icon-info-activity"">
                                        <i class=""mdi mdi-checkbox-marked-circle-outline bg-soft-success""></i>
                                    </div>
                                    <div class=""activity-info-text mb-2"">
                                        <div class=""mb-1"">
                                            <small class=""text-muted d-block mb-1"">10 Min ago</small>
                                            <a href=""#"" class=""m-0 w-75"">Task finished</a>
                                        </div>
                                        <p class=""text-muted mb-2 text-truncate"">There are many variations of passages.</p>
                                    </div>
                                </div>");
            WriteLiteral(@"

                                <div class=""activity-info"">
                                    <div class=""icon-info-activity"">
                                        <i class=""mdi mdi-timer-off bg-soft-pink""></i>
                                    </div>
                                    <div class=""activity-info-text mb-2"">
                                        <div class=""mb-1"">
                                            <small class=""text-muted d-block mb-1"">50 Min ago</small>
                                            <a href=""#"" class=""m-0 w-75"">Task Overdue</a>
                                        </div>
                                        <p class=""text-muted mb-2 text-truncate"">There are many variations of passages.</p>
                                        <span class=""badge badge-soft-secondary"">Design</span>
                                        <span class=""badge badge-soft-secondary"">HTML</span>
                                    </div>
                     ");
            WriteLiteral(@"           </div>
                                <div class=""activity-info"">
                                    <div class=""icon-info-activity"">
                                        <i class=""mdi mdi-alert-decagram bg-soft-purple""></i>
                                    </div>
                                    <div class=""activity-info-text mb-2"">
                                        <div class=""mb-1"">
                                            <small class=""text-muted d-block mb-1"">10 hours ago</small>
                                            <a href=""#"" class=""m-0 w-75"">New Task</a>
                                        </div>
                                        <p class=""text-muted mb-2 text-truncate"">There are many variations of passages.</p>
                                    </div>
                                </div>

                                <div class=""activity-info"">
                                    <div class=""icon-info-activity"">
                  ");
            WriteLiteral(@"                      <i class=""mdi mdi-clipboard-alert bg-soft-warning""></i>
                                    </div>
                                    <div class=""activity-info-text mb-2"">
                                        <div class=""mb-1"">
                                            <small class=""text-muted d-block mb-1"">yesterday</small>
                                            <a href=""#"" class=""m-0 w-75"">New Comment</a>
                                        </div>
                                        <p class=""text-muted mb-2 text-truncate"">There are many variations of passages.</p>
                                    </div>
                                </div>
                                <div class=""activity-info"">
                                    <div class=""icon-info-activity"">
                                        <i class=""mdi mdi-clipboard-alert bg-soft-secondary""></i>
                                    </div>
                                    <div cl");
            WriteLiteral(@"ass=""activity-info-text mb-2"">
                                        <div class=""mb-1"">
                                            <small class=""text-muted d-block mb-1"">01 feb 2020</small>
                                            <a href=""#"" class=""m-0 w-75"">New Lead Meting</a>
                                        </div>
                                        <p class=""text-muted mb-2 text-truncate"">There are many variations of passages.</p>
                                    </div>
                                </div>
                                <div class=""activity-info"">
                                    <div class=""icon-info-activity"">
                                        <i class=""mdi mdi-checkbox-marked-circle-outline bg-soft-success""></i>
                                    </div>
                                    <div class=""activity-info-text mb-2"">
                                        <div class=""mb-1"">
                                            <small clas");
            WriteLiteral(@"s=""text-muted d-block mb-1"">26 jan 2020</small>
                                            <a href=""#"" class=""m-0 w-75"">Task finished</a>
                                        </div>
                                        <p class=""text-muted mb-2 text-truncate"">There are many variations of passages.</p>
                                    </div>
                                </div>
                            </div><!--end activity-->
                        </div><!--end activity-scroll-->
                    </div><!--end tab-pane-->
                    <div class=""tab-pane"" id=""TasksTab"" role=""tabpanel"">
                        <div class=""m-0"">
                            <div id=""rightbar_chart"" class=""apex-charts""></div>
                        </div>
                        <div class=""text-center mt-n2 mb-2"">
                            <button type=""button"" class=""btn btn-soft-primary"">Create Project</button>
                            <button type=""button"" class=""btn btn-soft-");
            WriteLiteral(@"primary"">Create Task</button>
                        </div>
                        <div class=""slimscroll scroll-rightbar"">
                            <div class=""p-2"">
                                <div class=""media mb-3"">
                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "cb57bdd4eef5c31fba3c7b5058476b08285ea48315157", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                    <div class=""media-body align-self-center text-truncate ml-3"">
                                        <p class=""text-success font-weight-semibold mb-0 font-14"">Project</p>
                                        <h4 class=""mt-0 mb-0 font-weight-semibold text-dark font-18"">Payment App</h4>
                                    </div><!--end media-body-->
                                </div>
                                <span><b>Deadline:</b> 02 June 2020</span>
                                <a href=""javascript: void(0);"" class=""d-block mt-3"">
                                    <p class=""text-muted mb-0"">Complete Tasks<span class=""float-right"">75%</span></p>
                                    <div class=""progress mt-2"" style=""height: 4px;"">
                                        <div class=""progress-bar bg-secondary"" role=""progressbar"" style=""width: 75%"" aria-valuenow=""75"" aria-valuemin=""0"" aria-valuemax=""100""></div>
                                    </d");
            WriteLiteral(@"iv>
                                </a>
                            </div>
                            <hr class=""hr-dashed"">
                        </div>
                    </div><!--end tab-pane-->
                    <div class=""tab-pane"" id=""SettingsTab"" role=""tabpanel"">
                        <div class=""p-1 bg-light mx-n3"">
                            <h6 class=""px-3"">Account Settings</h6>
                        </div>
                        <div class=""p-2 text-left mt-3"">
                            <div class=""custom-control custom-switch switch-primary mb-3"">
                                <input type=""checkbox"" class=""custom-control-input"" id=""settings-switch1""");
            BeginWriteAttribute("checked", " checked=\"", 9945, "\"", 9955, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                <label class=""custom-control-label"" for=""settings-switch1"">Auto updates</label>
                            </div>

                            <div class=""custom-control custom-switch switch-primary mb-3"">
                                <input type=""checkbox"" class=""custom-control-input"" id=""settings-switch2"">
                                <label class=""custom-control-label"" for=""settings-switch2"">Location Permission</label>
                            </div>

                            <div class=""custom-control custom-switch switch-primary mb-3"">
                                <input type=""checkbox"" class=""custom-control-input"" id=""settings-switch3""");
            BeginWriteAttribute("checked", " checked=\"", 10665, "\"", 10675, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                <label class=""custom-control-label"" for=""settings-switch3"">Show offline Contacts</label>
                            </div>
                        </div>
                        <div class=""p-1 bg-light mx-n3"">
                            <h6 class=""px-3"">General Settings</h6>
                        </div>
                        <div class=""p-2 text-left mt-3"">
                            <div class=""custom-control custom-switch switch-primary mb-3"">
                                <input type=""checkbox"" class=""custom-control-input"" id=""settings-switch4""");
            BeginWriteAttribute("checked", " checked=\"", 11282, "\"", 11292, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                <label class=""custom-control-label"" for=""settings-switch4"">Show me Online</label>
                            </div>

                            <div class=""custom-control custom-switch switch-primary mb-3"">
                                <input type=""checkbox"" class=""custom-control-input"" id=""settings-switch5"">
                                <label class=""custom-control-label"" for=""settings-switch5"">Status visible to all</label>
                            </div>

                            <div class=""custom-control custom-switch switch-primary mb-3"">
                                <input type=""checkbox"" class=""custom-control-input"" id=""settings-switch6""");
            BeginWriteAttribute("checked", " checked=\"", 12006, "\"", 12016, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                <label class=""custom-control-label"" for=""settings-switch6"">Notifications Popup</label>
                            </div>
                        </div>
                    </div><!--end tab-pane-->
                </div> <!--end tab-content-->
            </div><!--end modal-body-->
        </div><!-- /.modal-content -->
    </div><!-- /.modal-dialog -->
</div><!-- /.modal -->");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
