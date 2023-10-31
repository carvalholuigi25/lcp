import Home from "./page";

export default function IndexPage({ params: {locale} }: { params: any }) {
  return (
    <>
      <Home params={locale} />
    </>
  )
}
