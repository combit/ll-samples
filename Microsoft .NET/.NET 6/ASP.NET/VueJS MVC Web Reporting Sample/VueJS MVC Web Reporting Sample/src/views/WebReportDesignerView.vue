<template>
    <div class="WebReportDesigner">
        <WebReportDesigner msg="DesignerComponent opened." />
    </div>
</template>

<script>
    // @ is an alias to /src
    import WebReportDesigner from '@/components/WebReportDesigner.vue'

    export default {
        name: 'WebReportDesignerView',
        components: {
            WebReportDesigner
        },
        mounted() {
            let wrdScript = document.createElement('script')
            wrdScript.setAttribute('src', 'https://localhost:5011/WebReportDesigner.js')
            document.head.appendChild(wrdScript)
        }
    }
</script>
