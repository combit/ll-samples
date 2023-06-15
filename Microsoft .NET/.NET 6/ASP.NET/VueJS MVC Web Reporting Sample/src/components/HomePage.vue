<template>
    <h1 style="text-align: center;">Vue.JS MVC Web Reporting Sample</h1>
    <br />
    <div class="createSomeMargin">
        <p>DE: In diesem Beispiel wird die Einbindung des WebReportDesigners und des WebReportViewers mit einem ASP.NET Core Backend und einem Vue.JS Frontend gezeigt.</p>
        <p>EN: This example shows the integration of the WebReportDesigner and the WebReportViewer with an ASP.NET Core backend and a Vue.JS frontend.</p>
        <br />
        <br />
        <div class="home-button-flex">
            <div class="button-on-home">
                <a class="nav-link text-bright button-text" href="https://localhost:5002/WebReportDesigner" target='_blank'>Design</a>
            </div>
            <div class="button-on-home">
                <a class="nav-link text-bright button-text" href="https://localhost:5002/WebReportViewer" target='_blank'>Preview</a>
            </div>
        </div>
    </div>

</template>

<script lang="ts">

</script>

<style>

    a {
        color: #0366d6;
    }

    .createSomeMargin {
        width: 80vw;
        margin-left: auto;
        margin-right: auto;
    }

    code {
        color: #e01a76;
    }

    .btn-primary {
        color: #fff;
        background-color: #1b6ec2;
        border-color: #1861ac;
    }

    .button-on-home {
        margin: 10px 5px;
        padding: 15px 30px;
        background: #0693e3;
        color: white;
        cursor: pointer;
        border-radius: 30px;
        border: none;
    }

    .home-button-flex {
        display: flex;
        justify-content: center;
        align-items: center;
    }

    .text-bright {
        color: antiquewhite;
    }

    #wrdFrame {
        width: 100vw !important;
        height: 100vh !important;
    }

    body > .container {
        padding: 0 !important;
        margin: 0 !important;
        max-width: 100vw !important;
        width: 100vw !important;
        height: 100vh !important;
    }

    .button-text {
        margin: 4px 6px 4px 6px;
    }
</style>